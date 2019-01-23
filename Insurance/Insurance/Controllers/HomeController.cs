using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Insurance.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Application(string firstName, string lastName, string emailAddress, string dateOfBirth, string carYear,
                                        string carMake, string carModel, string dUI, string speedingTickets, string coverageType)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(emailAddress) ||
                string.IsNullOrEmpty(dateOfBirth) || string.IsNullOrEmpty(carYear) || string.IsNullOrEmpty(carMake) || 
                string.IsNullOrEmpty(carModel) || string.IsNullOrEmpty(dUI) || string.IsNullOrEmpty(speedingTickets) ||
                string.IsNullOrEmpty(coverageType))
            {
                return View("~/Shared/Error.cshtml");
            }
            else
            {
                string connectionString = @"Data Source=MYDELL-PC\SQLEXPRESS;Initial Catalog=Insurance;
                                            Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;
                                            ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

                string queryString = @"INSERT INTO User (FirstName, LastName, EmailAddress, DateOfBirth, CarYear, CarMake, CarModel, Dui, SpeedingTickets, CoverageType) VALUES 
                                        @FirstName, @LastName, @EmailAddress, @DateOfBirth, @CarYear, @CarMake, @CarModel, @Dui, @SpeedingTickets, @CoverageType)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.Add("@FirstName", SqlDbType.VarChar);
                    command.Parameters.Add("@LastName", SqlDbType.VarChar);
                    command.Parameters.Add("@EmailAddress", SqlDbType.VarChar);
                    command.Parameters.Add("@DateOfBirth", SqlDbType.Int);
                    command.Parameters.Add("@CarYear", SqlDbType.Int);
                    command.Parameters.Add("@CarMake", SqlDbType.VarChar);
                    command.Parameters.Add("@CarModel", SqlDbType.VarChar);
                    command.Parameters.Add("@Dui", SqlDbType.Int);
                    command.Parameters.Add("@SpeedingTickets", SqlDbType.Int);
                    command.Parameters.Add("@CoverageType", SqlDbType.Int);


                }


                return View("Quote");
            }
        }

        ////Unused ActionResult Method
        //public ActionResult UseMe()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}