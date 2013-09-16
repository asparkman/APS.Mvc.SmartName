using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace II.Mvc.SmartName.POCOs
{
    public class UnderscoreDelimitedPerson
    {
        public virtual string first_name { get; set; }
        public virtual string last_name { get; set; }
        public virtual DateTime date_of_birth { get; set; }
    }
}
