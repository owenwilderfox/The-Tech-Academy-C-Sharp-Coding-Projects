using Insurance.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Insurance.Controllers
{
    public class QuoteController : Controller
    {
        private string connectionString = @"Data Source=MYDELL-PC\SQLEXPRESS;Initial Catalog=Insurance;
                                            Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;
                                            ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

    public ActionResult Quote()
        {
            string queryString = @"SELECT FirstName, LastName, DateOfBirth, CarYear, CarMake, CarModel
                                    Dui, SpeedingTickets, CoverageType from Users";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var applicant = new Applicant();
                    applicant.FirstName = reader["FirstName"].ToString();
                    applicant.LastName = reader["LastName"].ToString();
                    applicant.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    applicant.CarYear = Convert.ToInt32(reader["CarYear"]);
                    applicant.CarMake = reader["CarMake"].ToString();
                    applicant.CarModel = reader["CarModel"].ToString();
                    applicant.Dui = reader["Dui"].ToString();
                    applicant.SpeedingTickets = Convert.ToInt32(reader["SpeedingTickets"]);
                    applicant.CoverageType = reader["CoverageType"].ToString();
                    //applicant.Quote = Convert.ToDecimal(reader["Quote"]);

                }
            }
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