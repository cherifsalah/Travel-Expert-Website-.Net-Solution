using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Workshop5webformwithAuthentication
{
    public partial class Login : System.Web.UI.Page
    {

        List <Customer> lstCustomers;
        protected void Page_Load(object sender, EventArgs e)
        {
            //get all the Customers 
            lstCustomers = CustomerDB.GetCustomers();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //if user click on login verify if username password in Customer table
            //get Custemail and CustPassword from user
            string Custemail = txtEmail.Text;
            string Custpassword = txtPassword.Text;
            if (CustomerDB.IsCustomer(lstCustomers, Custemail, Custpassword))
            {
                Session["CustEmail"] = Custemail;
                

                //change the bar for a login Customer
                Session["Logout"] = "Logout";
                //hide register bar
                Session["Register"] = "";
                //hide login
                Session["Login"] = "";
                //show Detail
                Session["Detail"] = "View Packages";
                //show booking
                Session["Booking"] = "Booking";
                //show update
                Session["Update"] = "Update";
                //redirect to booking page
                Response.Redirect("Booking.aspx");


            }
            
        }
    }
}