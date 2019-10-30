using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Workshop5webformwithAuthentication.App_Code
{
    public class PackagesDB
    {
        // This function gets all the packages
        public static List<Packages> GetPackages(string CustEmail)
        {
            // List of all packages
            List<Packages> PkgList = new List<Packages>();
            Packages Pkg = null;


            // Selecting all customers based on email
            string query = "SELECT SUM(P.PkgBasePrice) CostOfAllPackages," +
                "(SUM(P.PkgBasePrice))/P.PkgBasePrice CountOfPackagesBought, " +
                "p.PkgDesc, P.PkgBasePrice, P.PkgName, C.CustFirstName, c.CustLastName,              " +
                "c.CustEmail FROM PACKAGES P INNER JOIN BOOKINGS B ON P.PackageId = B.PackageId " +
                "INNER JOIN CUSTOMERS C ON C.CustomerId = B.CustomerId " +
                "where c.CustEmail = @CustEmail GROUP BY c.CustEmail, P.PkgName, P.PkgBasePrice, " +
                "C.CustFirstName, c.CustLastName, p.PkgDesc";
            // SQL Connection
            SqlConnection Connection = TravelExpertsDB.GetConnection();
            // SQL Command
            SqlCommand cmd = new SqlCommand(query, Connection);
            // Adding the parameter of customer email
            cmd.Parameters.AddWithValue("@CustEmail", CustEmail);
            try
            {
                // opening the connection 
                Connection.Open();
                // Executing the reading function
                SqlDataReader reader = cmd.ExecuteReader();
                // Reading until we are done with reading
                while (reader.Read())
                {
                    // Getting property by property
                    Pkg = new Packages();
                    Pkg.PkgDesc = reader["PkgDesc"].ToString();
                    Pkg.PkgBasePrice = Math.Round(Convert.ToDecimal(reader["PkgBasePrice"]), 2);
                    Pkg.PkgName = reader["PkgName"].ToString();
                    Pkg.CostOfAllPackages = Math.Round(Convert.ToDecimal(reader["CostOfAllPackages"]), 2);
                    Pkg.CountOfPackagesBought = Convert.ToInt32(reader["CountOfPackagesBought"]);
                    Pkg.CustEmail = reader["CustEmail"].ToString();
                    Pkg.CustFirstName = reader["CustFirstName"].ToString();
                    Pkg.CustLastName = reader["CustLastName"].ToString();
                    // Adding to the list of packages
                    PkgList.Add(Pkg);
                }
            }
            catch (Exception ex)
            {
                // Throwing the exception
                throw ex;
            }
            finally
            {
                // Closing the connection when done with the execution
                Connection.Close();
            }
            // Returning the list of objects
            return PkgList;
        }


    }
}