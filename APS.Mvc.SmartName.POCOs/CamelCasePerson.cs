using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace APS.Mvc.SmartName.POCOs
{
    public class CamelCasePerson
    {
        [Display(Name = "This is the custom display property!")]
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set;  }
        public virtual DateTime DateOfBirth { get; set; }
    }
}
