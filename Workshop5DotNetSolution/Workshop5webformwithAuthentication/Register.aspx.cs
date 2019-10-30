using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Workshop5webformwithAuthentication;

namespace Workshop5webformwithAuthentication
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        
        List<Customer> lstCust;
        protected void Page_Load(object sender, EventArgs e)
        {
            //GET All customers
            lstCust = CustomerDB.GetCustomers();
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // create connection
            //test if another customer is registered with this email
            if (CustomerDB.EmailExistInListCustomer(lstCust, tbEmail.Text))
            {
                lblErrorMessage.Text = "This Email is taken by another Customer!";
            }
            else
            {
                //create a customer from form

                SqlConnection connection = TravelExpertsDB.GetConnection();
                //TODO: insert one field to store username and password, then encrypt it and save it as well

                string query = "INSERT INTO CUSTOMERS (" +
                    "   CustFirstName" +
                    "  ,CustLastName" +
                    "  ,CustAddress" +
                    "  ,CustCity" +
                    "  ,CustProv" +
                    "  ,CustPostal" +
                    "  ,CustCountry" +
                    "  ,CustHomePhone" +
                    "  ,CustBusPhone" +
                    "  ,CustEmail" +
                    "  ,CustPassword" +
                    ")" +
                    " VALUES (@CustFirstName" +
                    "  , @CustLastName" +
                    "  , @CustAddress" +
                    "  , @CustCity" +
                    "  , @CustProv" +
                    "  , @CustPostal" +
                    "  , @CustCountry" +
                    "  , @CustHomePhone" +
                    "  , @CustBusPhone" +
                    "  , @CustEmail" +
                    "  , @CustPassword" +
                    ") ";
                SqlCommand cmd = new SqlCommand(query, connection);
                // supply parameter value
                cmd.Parameters.AddWithValue("@CustFirstName", tbFirstName.Text);
                cmd.Parameters.AddWithValue("@CustLastName", tbLastName.Text);
                cmd.Parameters.AddWithValue("@CustAddress", tbAddress.Text);
                cmd.Parameters.AddWithValue("@CustCity", tbCity.Text);
                cmd.Parameters.AddWithValue("@CustProv", ddlProvince.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@CustPostal", tbPostCode.Text);
                if (tbCountry.Text != null)
                    cmd.Parameters.AddWithValue("@CustCountry", tbCountry.Text);
                else
                    cmd.Parameters.AddWithValue("@CustCountry", DBNull.Value);

                if (tbHomePhone.Text != null)
                    cmd.Parameters.AddWithValue("@CustHomePhone", tbHomePhone.Text);
                else
                    cmd.Parameters.AddWithValue("@CustHomePhone", DBNull.Value);

                cmd.Parameters.AddWithValue("@CustBusPhone", tbBusPhone.Text);
                cmd.Parameters.AddWithValue("@CustEmail", tbEmail.Text);
                cmd.Parameters.AddWithValue("@CustPassword", Encryption.GetEncyptedValue( tbPassword.Text,"Hello12"));

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();

                    // get the generated ID - current identity value for  Customer table
                    string selectQuery = "SELECT IDENT_CURRENT('Customers') FROM Customers";
                    SqlCommand selectCmd = new SqlCommand(selectQuery, connection);
                    int CustID = Convert.ToInt32(selectCmd.ExecuteScalar());
                    //redirect to login
                    if (CustID > 1)
                    {
                        Response.Redirect("Login.aspx");
                    }
                    else
                    {
                        lblErrorMessage.Text = "Registration Unsuccessful ";
                        lblErrorMessage.ForeColor = System.Drawing.Color.Red;
                    }

                    //Response.Redirect("login.aspx");

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
            
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            //disable validation
            

            tbFirstName.Text = "";
            tbLastName.Text = "";
            tbAddress.Text = "";
            tbCity.Text = "";
            
            tbPostCode.Text = "";
            tbCountry.Text = "";
            tbHomePhone.Text = "";
            tbBusPhone.Text = "";
            tbEmail.Text = "";
            tbPassword.Text = "";
            tbConfirmPassword.Text = "";
        }

       
    }
}