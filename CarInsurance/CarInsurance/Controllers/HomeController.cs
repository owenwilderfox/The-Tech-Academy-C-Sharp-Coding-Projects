using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsurance.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Application(string FirstName, string LastName, string EmailAddress, string DateOfBirth, string CarYear, string CarMake,
            string CarModel, string Dui, string MovingViolations, string CoverageType)
        {
            if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName) || string.IsNullOrEmpty(EmailAddress) || string.IsNullOrEmpty(DateOfBirth) ||
                string.IsNullOrEmpty(CarYear) || string.IsNullOrEmpty(CarModel) || string.IsNullOrEmpty(Dui) || string.IsNullOrEmpty(MovingViolations) ||
                string.IsNullOrEmpty(CoverageType))
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                string connectionString = @"Data Source=MYDELL-PC\SQLEXPRESS;Initial Catalog=CarInsurance;Integrated Security=True;
                                            Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;
                                            MultiSubnetFailover=False";

                string queryString = @"INSERT INTO CarInsurance (FirstName, LastName, EmailAddress, DateOfBirth, CarYear, CarMake,
                                        CarModel, Dui, MovingViolations, CoverageType) VALUES (@FirstName, @LastName, @EmailAddress,
                                        @DateOfBirth, @CarYear, @CarMake, @CarModel, @Dui, @MovingViolations, @CoverageType)";

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
                    command.Parameters.Add("@MovingViolations", SqlDbType.Int);
                    command.Parameters.Add("@CoverageType", SqlDbType.VarChar);

                    command.Parameters["@FirstName"].Value = FirstName;
                    command.Parameters["@LastName"].Value = LastName;
                    command.Parameters["@EmailAddress"].Value = EmailAddress;
                    command.Parameters["@DateOfBirth"].Value = DateOfBirth;
                    command.Parameters["@CarYear"].Value = CarYear;
                    command.Parameters["@CarMake"].Value = CarMake;
                    command.Parameters["@CarModel"].Value = CarModel;
                    command.Parameters["@Dui"].Value = Dui;
                    command.Parameters["@MovingViolations"].Value = MovingViolations;
                    command.Parameters[""]

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                    return View("~/Views/Quote");
            }
        }
    }
}