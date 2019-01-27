using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StPeregrineHealthSystem.Models;

namespace StPeregrineHealthSystem.DAL
{
    public class HospitalInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<HospitalContext>
    {
        protected override void Seed(HospitalContext context)
        {
            var patients = new List<Patient>
            {
            new Patient{FirstName="Gregory Alan",LastName="Isakov",BirthDate=DateTime.Parse("1979-10-19")},
            new Patient{FirstName="Ben",LastName="Schneider",BirthDate=DateTime.Parse("1987-09-29")},
            new Patient{FirstName="Arturo",LastName="Renaud",BirthDate=DateTime.Parse("2003-05-31")},
            new Patient{FirstName="Florence",LastName="Welch",BirthDate=DateTime.Parse("2002-09-01")},
            new Patient{FirstName="Yan",LastName="Tiersen",BirthDate=DateTime.Parse("1980-12-01")}
            };

            patients.ForEach(s => context.Patients.Add(s));
            context.SaveChanges();
        }
    }
}