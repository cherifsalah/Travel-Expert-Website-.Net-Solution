using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Workshop5webformwithAuthentication.App_Code
{
    public static class CustomersDB
    {

        // This function is used to get all of the customers
        public static Customers GetCustomers(string CustEmail)
        {
            Customers Cust = null;
            // Selecting all customers based on email
            String Custquery = "SELECT * FROM Customers WHERE [CustEmail] = @CustEmail";
            // SQL Connection
            SqlConnection Connection = TravelExpertsDB.GetConnection();
            // SQL Command
            SqlCommand cmd = new SqlCommand(Custquery, Connection);
            // Adding the parameter of customer email
            cmd.Parameters.AddWithValue("@CustEmail", CustEmail);


            /////////////////////////////////////////////////////////////////
            try
            {
                // opening the connection 
                Connection.Open();
                // Reading data from reader function 
                SqlDataReader reader = cmd.ExecuteReader();
                // Reading until we are done with reading
                while (reader.Read())
                {
                    Cust = new Customers();
                    // Getting property by property
                    Cust.CustFirstName = reader["CustFirstName"].ToString();
                    Cust.CustLastName = reader["CustLastName"].ToString();
                    Cust.CustAddress = reader["CustAddress"].ToString();
                    Cust.CustCity = reader["CustCity"].ToString();
                    Cust.CustProv = reader["CustProv"].ToString();
                    if (reader["CustCountry"] == DBNull.Value)
                        Cust.CustCountry = null;
                    else
                        Cust.CustCountry = reader["CustCountry"].ToString();
                    if (reader["CustHomePhone"] == DBNull.Value)
                        Cust.CustHomePhone = 6958479876;
                    else
                        Cust.CustHomePhone = Convert.ToInt64(reader["CustHomePhone"]);
                    if (reader["CustBusPhone"] == DBNull.Value)
                        Cust.CustBusPhone = 695847987;
                    else
                        Cust.CustBusPhone = Convert.ToInt64(reader["CustBusPhone"]);
                    Cust.CustEmail = reader["CustEmail"].ToString();
                    if (reader["CustPostal"] == DBNull.Value)
                        Cust.CustPostalCode = null;
                    else
                        Cust.CustPostalCode = reader["CustPostal"].ToString();
                    Cust.Password = reader["Password"].ToString();
                }
            }
            catch (Exception ex)
            {
                // Throwing exception
                throw ex;
            }
            finally
            {
                // Closing the connection when done with the execution
                Connection.Close();
            }
            // Returning the list of objects
            return Cust;
        }
        // Getting only the name of the customers
        public static string GetCustomer(string CustEmail, string Password)
        {
            string CustFirstName = "";
            // Selecting all customers based on email and password
            String Custquery = "SELECT CustFirstName FROM customers WHERE [CustEmail] = @CustEmail AND PASSWORD =@PASSWORD";
            // SQL Connection
            SqlConnection Connection = TravelExpertsDB.GetConnection();
            // SQL Command
            SqlCommand cmd = new SqlCommand(Custquery, Connection);
            // Adding the parameter of customer email
            cmd.Parameters.AddWithValue("@CustEmail", CustEmail);
            cmd.Parameters.AddWithValue("@Password", Password);

            try
            {
                // opening the connection 
                Connection.Open();
                // Reading data from reader function 
                SqlDataReader reader = cmd.ExecuteReader();
                // Reading until we are done with reading
                while (reader.Read())
                {
                    // Getting property by property
                    CustFirstName = reader["CustFirstName"].ToString();
                }
            }
            catch (Exception ex)
            {
                // Throwing the error
                throw ex;
            }
            finally
            {
                // Closing the connection when done with the execution
                Connection.Close();
            }
            // Returning the list of objects
            return CustFirstName;
        }
        // This function is used to login for customers
        public static bool Login(string CustEmail, string Password)
        {
            // bool variable to set either it is successful login or not
            bool result = false;
            // List of Customer Email
            List<Customers> CustEmailLst = new List<Customers>();
            Customers Cust = null;
            // Selecting all customers email and password based on email and password given by customer
            String CustEmailquery = "SELECT [CustEmail], PASSWORD FROM customers WHERE [CustEmail] = @CustEmail AND PASSWORD =@PASSWORD";
            // SQL Connection
            SqlConnection Connection = TravelExpertsDB.GetConnection();
            // SQL Command
            SqlCommand cmd = new SqlCommand(CustEmailquery, Connection);
            // Adding the parameter of customer email and password
            cmd.Parameters.AddWithValue("@CustEmail", CustEmail);
            cmd.Parameters.AddWithValue("@Password", Password);

            try
            {
                // opening the connection 
                Connection.Open();
                // Reading data from reader function 
                SqlDataReader reader = cmd.ExecuteReader();
                // Reading until we are done with reading
                while (reader.Read())
                {
                    // Getting property by property
                    Cust = new Customers();
                    Cust.CustEmail = reader["CustEmail"].ToString();
                    Cust.Password = reader["Password"].ToString();
                    // Adding to the list
                    CustEmailLst.Add(Cust);
                }
                foreach (var item in CustEmailLst)
                {
                    // Checking whether the given id and password is correct or not
                    if (item.CustEmail == CustEmail && item.Password == Password)
                        // return true if matched
                        result = true;
                    else
                        // return false if not matched
                        result = false;
                }

            }
            catch (Exception ex)
            {
                // throwing exception
                throw ex;
            }
            finally
            {
                // Closing the connection when done with the execution
                Connection.Close();
            }
            // Returning the list of objects
            return result;
        }
        // This function is used to add a customer or register a customer
        public static bool addCustomer(string CustFirstName, string CustLastName, string CustAddress, string CustCity, string CustProvince, string CustPostalCode, string CustCountry, string CustHomePhone, string CustBusPhone, string CustEmail, string Password)
        {
            // bool variable for successful registration or false for failed registration
            bool result = false;
            // Insert all customers information based on email
            string query = "INSERT INTO Customers(CustFirstName, CustLastName, CustAddress, CustCity, CustProv, CustPostal, CustCountry, CustHomePhone, CustBusPhone, CustEmail, Password)VALUES(@CustFirstName, @CustLastName, @CustAddress, @CustCity, @CustProvince, @CustPostalCode, @CustCountry, @CustHomePhone, @CustBusPhone, @CustEmail, @Password)";
            // SQL Connection
            SqlConnection Connection = TravelExpertsDB.GetConnection();
            // SQL Command
            SqlCommand cmd = new SqlCommand(query, Connection);
            // Adding the parameter of customer properties
            cmd.Parameters.AddWithValue("@CustFirstName", CustFirstName);
            cmd.Parameters.AddWithValue("@CustLastName", CustLastName);
            cmd.Parameters.AddWithValue("@CustAddress", CustAddress);
            cmd.Parameters.AddWithValue("@CustCity", CustCity);
            cmd.Parameters.AddWithValue("@CustProvince", CustProvince);
            cmd.Parameters.AddWithValue("@CustPostalCode", CustPostalCode);
            cmd.Parameters.AddWithValue("@CustCountry", CustCountry);
            cmd.Parameters.AddWithValue("@CustHomePhone", CustHomePhone);
            cmd.Parameters.AddWithValue("@CustBusPhone", CustBusPhone);
            cmd.Parameters.AddWithValue("@CustEmail", CustEmail);
            cmd.Parameters.AddWithValue("@Password", Password);
            try
            {
                // opening the connection 
                Connection.Open();
                // Executing the query
                cmd.ExecuteNonQuery();
                // setting the boolean to true
                result = true;
            }
            catch (Exception ex)
            {
                // throwing exception
                throw ex;
            }
            // Returning the list of objects
            return result;
        }
        // Updating the customer profile
        public static bool UpdateCustomer(string CustFirstName, string CustLastName, string CustAddress, string CustCity, string CustProvince, string CustPostalCode, string CustCountry, string CustHomePhone, string CustBusPhone, string CustEmail)
        {
            // Boolean variable to check either update is successful or fail
            bool result = false;
            // updating all customers information based on email
            string query = "UPDATE CUSTOMERS SET CustFirstName = @CustFirstName, CustLastName = @CustLastName, CustAddress = @CustAddress, CustCity = @CustCity, CustProv = @CustProvince, CustPostal = @CustPostalCode, CustCountry = @CustCountry, CustHomePhone = @CustHomePhone, CustBusPhone = @CustBusPhone, CustEmail = @CustEmail WHERE CustEmail = @CustEmail";
            // SQL Connection
            SqlConnection Connection = TravelExpertsDB.GetConnection();
            // SQL Command
            SqlCommand cmd = new SqlCommand(query, Connection);
            // Adding the parameter of customer value passed
            cmd.Parameters.AddWithValue("@CustFirstName", CustFirstName);
            cmd.Parameters.AddWithValue("@CustLastName", CustLastName);
            cmd.Parameters.AddWithValue("@CustAddress", CustAddress);
            cmd.Parameters.AddWithValue("@CustCity", CustCity);
            cmd.Parameters.AddWithValue("@CustProvince", CustProvince);
            cmd.Parameters.AddWithValue("@CustPostalCode", CustPostalCode);
            cmd.Parameters.AddWithValue("@CustCountry", CustCountry);
            cmd.Parameters.AddWithValue("@CustHomePhone", CustHomePhone);
            cmd.Parameters.AddWithValue("@CustBusPhone", CustBusPhone);
            cmd.Parameters.AddWithValue("@CustEmail", CustEmail);
            try
            {
                // opening the connection 
                Connection.Open();
                // executing the query
                cmd.ExecuteNonQuery();
                // setting the boolean value to be true
                result = true;
            }
            catch (Exception ex)
            {
                // throwing the exception
                throw ex;
            }
            // returning the value
            return result;
        }
    }
}