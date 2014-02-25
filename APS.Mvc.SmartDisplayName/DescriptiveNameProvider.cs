using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APS.Mvc.SmartDisplayName
{
    public abstract class DescriptiveNameProvider
    {
        public abstract string GetDescriptiveName(string anyCasedString);

        public static DescriptiveNameProvider Current { get; set; }
    }
}
