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

                string queryString = @"INSERT INTO Users (FirstName, LastName, EmailAddress, DateOfBirth, CarYear, CarMake, CarModel, Dui, SpeedingTickets, CoverageType) VALUES 
                                        (@FirstName, @LastName, @EmailAddress, @DateOfBirth, @CarYear, @CarMake, @CarModel, @Dui, @SpeedingTickets, @CoverageType)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.Add("@FirstName", SqlDbType.VarChar);
                    command.Parameters.Add("@LastName", SqlDbType.VarChar);
                    command.Parameters.Add("@EmailAddress", SqlDbType.VarChar);
                    command.Parameters.Add("@DateOfBirth", SqlDbType.Date);
                    command.Parameters.Add("@CarYear", SqlDbType.Int);
                    command.Parameters.Add("@CarMake", SqlDbType.VarChar);
                    command.Parameters.Add("@CarModel", SqlDbType.VarChar);
                    command.Parameters.Add("@Dui", SqlDbType.VarChar);
                    command.Parameters.Add("@SpeedingTickets", SqlDbType.Int);
                    command.Parameters.Add("@CoverageType", SqlDbType.VarChar);

                    command.Parameters["@FirstName"].Value = firstName;
                    command.Parameters["@LastName"].Value = lastName;
                    command.Parameters["@EmailAddress"].Value = emailAddress;
                    command.Parameters["@DateOfBirth"].Value = dateOfBirth;
                    command.Parameters["@CarYear"].Value = Convert.ToInt32(carYear);
                    command.Parameters["@CarMake"].Value = carMake;
                    command.Parameters["@CarModel"].Value = carModel;
                    command.Parameters["@Dui"].Value = dUI;
                    command.Parameters["@SpeedingTickets"].Value = Convert.ToInt32(speedingTickets);
                    command.Parameters["@coverageType"].Value = coverageType;

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }


                return View("Quote");
            }
        }

        public ActionResult Admin()
        {
            return View();
        }
        ////Unused ActionResult Method
        //public ActionResult UseMe()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}