using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StPeregrineHealthSystem.Models
{
    public class Physician
    {
        public int PhysicianID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Speciality { get; set; }

        public virtual Patient Patient { get; set; }
    }
}