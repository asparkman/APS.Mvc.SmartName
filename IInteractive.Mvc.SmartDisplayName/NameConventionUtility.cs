using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Configuration;
using II.Mvc.SmartName.Properties;

namespace IInteractive.Mvc.SmartDisplayName
{
    public class NameConventionUtility : DescriptiveNameProvider
    {
        public NameConventionUtility()
        {
            Acronyms = new List<string>();
            Prepositions = new List<string>();
            Articles = new List<string>();

            string decapPreps = ConfigurationManager.AppSettings["DecapitalizePrepositions"];
            string decapArticles = ConfigurationManager.AppSettings["DecapitalizeArticles"];
            string capAcros = ConfigurationManager.AppSettings["CapitalizeAcronyms"];

            DecapitalizePrepositions = GetAppSettingValue(decapPreps).HasValue ? GetAppSettingValue(decapPreps).Value : true;
            DecapitalizeArticles = GetAppSettingValue(decapArticles).HasValue ? GetAppSettingValue(decapArticles).Value : true;
            CapitalizeAcronyms = GetAppSettingValue(capAcros).HasValue ? GetAppSettingValue(capAcros).Value : true;

            Acronyms = GetResourceList(Resources.DefaultAcronyms);
            Prepositions = GetResourceList(Resources.DefaultPrepositions);
            Articles = GetResourceList(Resources.DefaultArticles);
        }

        public List<string> Acronyms { get; set; }
        public List<string> Prepositions { get; set; }
        public List<string> Articles { get; set; }

        public bool DecapitalizePrepositions { get; set; }
        public bool DecapitalizeArticles { get; set; }
        public bool CapitalizeAcronyms { get; set; }

        protected Boolean? GetAppSettingValue(string val)
        {
            Boolean? setting = null;
            if (!string.IsNullOrEmpty(val))
            {
                if (Boolean.FalseString.Equals(val, StringComparison.CurrentCultureIgnoreCase))
                {
                    setting = false;
                }
                else if (Boolean.TrueString.Equals(val, StringComparison.CurrentCultureIgnoreCase))
                {
                    setting = true;
                }
            }

            return setting;
        }

        protected List<string> GetResourceList(string resource)
        {
            return resource
                .Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None)
                .Select(x => x.Trim())
                .ToList();
        }

        public override string GetDescriptiveName(string anyCasedString)
        {
            string result = null;
            if (ContainsLines(anyCasedString))
            {
                result = UndoLineDelimiting(anyCasedString);
            }
            else
            {
                result = UndoCamelCasing(anyCasedString);
            }
            result = FixCapitilization(result);
            return result;
        }

        public virtual string UndoCamelCasing(string camelCasedString)
        {
            var result = Regex.Replace(camelCasedString,
                            @"(?<a>(?<!^)[A-Z][a-z])", @" ${a}");
            result = Regex.Replace(result,
                                        @"(?<a>[a-z])(?<b>[A-Z0-9])", @"${a} ${b}");
            return result;
        }

        public virtual string FixCapitilization(string uncappedString)
        {
            var words = uncappedString.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (i != 0 && (DecapitalizePrepositions && Prepositions.Contains(words[i], StringComparer.CurrentCultureIgnoreCase)
                    || DecapitalizeArticles && Articles.Contains(words[i], StringComparer.CurrentCultureIgnoreCase)))
                {
                    words[i] = words[i].Substring(0, 1).ToLower() + words[i].Substring(1);
                }
                else if(CapitalizeAcronyms && Acronyms.Contains(words[i], StringComparer.CurrentCultureIgnoreCase))
                {
                    words[i] = words[i].ToUpper();
                }
                else
                {
                    words[i] = words[i].Substring(0, 1).ToUpper() + words[i].Substring(1);
                }
            }
            return String.Join(" ", words);
        }

        public virtual string UndoLineDelimiting(string underscoredString)
        {
            return underscoredString.Replace('_', ' ').Replace('-', ' ');
        }

        public virtual bool ContainsLines(string anyCasedString)
        {
            return anyCasedString.Contains('_') || anyCasedString.Contains('-');
        }
    }
}
