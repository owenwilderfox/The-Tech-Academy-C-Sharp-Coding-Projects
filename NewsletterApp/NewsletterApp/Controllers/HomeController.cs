using NewsletterApp.Models;
using NewsletterApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsletterApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly string connectionString = @"Data Source=MYDELL-PC\SQLEXPRESS;Initial Catalog=Newsletter;
                                            Integrated Security=True;Connect Timeout=30;Encrypt=False;
                                            TrustServerCertificate=False;ApplicationIntent=ReadWrite;
                                            MultiSubnetFailover=False";

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(string firstName, string lastName, string emailAddress)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(emailAddress))
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                using (NewsletterEntities db = new NewsletterEntities())
                {
                    var signup = new SignUp();
                    signup.FirstName = firstName;
                    signup.LastName = lastName;
                    signup.EmailAddress = emailAddress;

                    db.SignUps.Add(signup);
                    db.SaveChanges();
                }
            }

            return View("Success");
        }

        public ActionResult Admin()
        {
            using (NewsletterEntities db = new NewsletterEntities())
            {
                var signups = db.SignUps;
                var signupVMs = new List<SignUpVM>();
                foreach (var signup in signups)
                {
                    var signupVM = new SignUpVM();
                    signupVM.FirstName = signup.FirstName;
                    signupVM.LastName = signup.LastName;
                    signupVM.EmailAddress = signup.EmailAddress;
                    signupVMs.Add(signupVM);
                }

                return View(signupVMs);
            }
        }
    }

}