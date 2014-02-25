using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace APS.Mvc.SmartDisplayName
{
    public class SmartDisplayNameMetaDataProvider : DataAnnotationsModelMetadataProvider
    {
        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
        {
            var result = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);

            List<Attribute> attributeList = new List<Attribute>(attributes);
            DisplayAttribute display = attributes.OfType<DisplayAttribute>().FirstOrDefault();
            string name = null;
            if (display != null)
            {
                result.Description = display.GetDescription();
                result.ShortDisplayName = display.GetShortName();
                result.Watermark = display.GetPrompt();
                result.Order = display.GetOrder() ?? ModelMetadata.DefaultOrder;

                name = display.GetName();
            }

            if (name != null)
            {
                result.DisplayName = name;
            }
            else
            {
                DisplayNameAttribute displayNameAttribute = attributeList.OfType<DisplayNameAttribute>().FirstOrDefault();
                if (displayNameAttribute != null)
                {
                    result.DisplayName = displayNameAttribute.DisplayName;
                }
                else if (!string.IsNullOrEmpty(propertyName))
                {
                    result.DisplayName = DescriptiveNameProvider.Current.GetDescriptiveName(propertyName);
                }
            }

            return result;
        }
    }
}