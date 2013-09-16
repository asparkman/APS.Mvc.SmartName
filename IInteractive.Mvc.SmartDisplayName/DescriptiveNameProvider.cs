using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IInteractive.Mvc.SmartDisplayName
{
    public abstract class DescriptiveNameProvider
    {
        public abstract string GetDescriptiveName(string anyCasedString);

        public static DescriptiveNameProvider Current { get; set; }
    }
}
