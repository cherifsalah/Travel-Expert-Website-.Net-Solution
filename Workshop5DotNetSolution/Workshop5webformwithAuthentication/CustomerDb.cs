using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


namespace Workshop5webformwithAuthentication
{
   
        public static class CustomerDB
        {

            // This function is used to get all of the customers
            public static List<Customer> GetCustomers()
            {
                Customer Cust;
                List<Customer> lstresult = new List<Customer>();
                // Selecting all customers based on emailnew
                String Custquery = "SELECT * FROM Customers ";
                // SQL Connection
                SqlConnection Connection = TravelExpertsDB.GetConnection();
                // SQL Command
                SqlCommand cmd = new SqlCommand(Custquery, Connection);



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
                        Cust = new Customer();
                        // Getting property by property
                        Cust.CustomerID = Convert.ToInt32(reader["CustomerId"].ToString());
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
                            Cust.CustHomePhone = null;
                        else
                            Cust.CustHomePhone = reader["CustHomePhone"].ToString();
                        if (reader["CustBusPhone"] == DBNull.Value)
                            Cust.CustBusPhone = null;
                        else
                            Cust.CustBusPhone = reader["CustBusPhone"].ToString();
                        Cust.CustEmail = reader["CustEmail"].ToString().Trim();

                        Cust.CustPostalCode = reader["CustPostal"].ToString();
                        //decrypt the password 
                        Cust.Password = Encryption.GetDecryptedValue( reader["CustPassword"].ToString().Trim(),"Hello12");
                        //add this customer to the list of customer
                        lstresult.Add(Cust);

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
                // Returning the list of custmers
                return lstresult;
            }


            //return true if customer can login
            public static bool IsCustomer(List<Customer> lstCustomers, string CustEmail, string CustPassword)
            {
                bool is_customer = false;
                foreach (Customer Cust in lstCustomers)
                {
                    if (Cust.CustEmail == CustEmail && Cust.Password == CustPassword)
                    {
                        is_customer = true;
                        break;
                    }
                }

                return is_customer;
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
                List<Customer> CustEmailLst = new List<Customer>();
                Customer Cust = null;
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
                        Cust = new Customer();
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
          
        //update customer custov with new value in custnv
        public static bool UpdateCustomer(Customer custov, Customer custnv)
        {

            // Boolean variable to check either update is successful or fail
            bool result = false;
            // updating all customers information based on email
            string query = "UPDATE CUSTOMERS SET " +
                "CustFirstName = @NewCustFirstName, " +
                "CustLastName = @NewCustLastName, " +
                "CustAddress = @NewCustAddress, " +
                "CustCity = @NewCustCity, " +
                "CustProv = @NewCustProvince, " +
                "CustPostal = @NewCustPostalCode, "+
                "CustCountry = @NewCustCountry, " +
                "CustHomePhone = @NewCustHomePhone, " +
                "CustBusPhone = @NewCustBusPhone, " +
                "CustEmail = @NewCustEmail " +
                " WHERE CustomerId=@oldCustId and  CustEmail = @oldCustEmail";
            // SQL Connection
            SqlConnection Connection = TravelExpertsDB.GetConnection();
            // SQL Command
            SqlCommand cmd = new SqlCommand(query, Connection);
            // Adding the parameter of customer value passed
            cmd.Parameters.AddWithValue("@NewCustFirstName", custnv.CustFirstName);
            cmd.Parameters.AddWithValue("@NewCustLastName", custnv.CustLastName);
            cmd.Parameters.AddWithValue("@NewCustAddress", custnv.CustAddress);
            cmd.Parameters.AddWithValue("@NewCustCity", custnv.CustCity);
            cmd.Parameters.AddWithValue("@NewCustProvince", custnv.CustProv);
            cmd.Parameters.AddWithValue("@NewCustPostalCode", custnv.CustPostalCode);
            if (custnv.CustCountry != null)
                cmd.Parameters.AddWithValue("@NewCustCountry", custnv.CustCountry);
            else
                cmd.Parameters.AddWithValue("@NewCustCountry", DBNull.Value);
            if (custnv.CustHomePhone != null)
                cmd.Parameters.AddWithValue("@NewCustHomePhone", custnv.CustHomePhone);
            else
                cmd.Parameters.AddWithValue("@NewCustHomePhone", DBNull.Value);
            cmd.Parameters.AddWithValue("@NewCustBusPhone", custnv.CustBusPhone);
            cmd.Parameters.AddWithValue("@NewCustEmail", custnv.CustEmail);
            cmd.Parameters.AddWithValue("@NewCustPassword", Encryption.GetEncyptedValue(custnv.Password, "Hello12"));
            cmd.Parameters.AddWithValue("@oldCustId", custov.CustomerID);
            cmd.Parameters.AddWithValue("@oldCustEmail", custov.CustEmail);
            

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
        public static int GetCustomerIDByEmail(string CustEmail, List<Customer> lstCust)
        {
            int Custid = 0;
            foreach (Customer cust in lstCust)
            {
                if (cust.CustEmail == CustEmail)
                {
                    Custid = cust.CustomerID;
                    break;
                }
            }
            return Custid;

        }
        //get a customer of a given customerId
        public static Customer GetCustomerByID(int custId, List<Customer> lstCust)
        {
            Customer Customer = null;
            foreach (Customer cust in lstCust)
            {
                if (cust.CustomerID == custId)
                {
                    Customer = cust;
                    break;
                }
            }
            return Customer;
        }
        //return true is email exist in list of customer
        public static bool EmailExistInListCustomer(List <Customer>lstCust, string CustEmail)
        {
            bool emailexist = false;
            foreach (Customer Cust in lstCust)
            {
                if (Cust.CustEmail == CustEmail)
                {
                    emailexist = true;
                    break;
                }
            }
            return emailexist;

            }

        }
    
}