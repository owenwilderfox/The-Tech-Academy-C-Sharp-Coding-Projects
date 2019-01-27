using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StPeregrineHealthSystem.Models
{
    public class Patient
    {
        public int PatientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual ICollection<Physician> Physicians { get; set; }
    }
}