using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Workshop5webformwithAuthentication
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        Customer custov ;
        List<Customer> lstCust;
        protected void Page_Load(object sender, EventArgs e)
        {
             
            //GET All customers
            lstCust = CustomerDB.GetCustomers();
            //get customer logedin
            string custEmail = Session["CustEmail"].ToString();
            int custid = CustomerDB.GetCustomerIDByEmail(custEmail, lstCust);
            custov = CustomerDB.GetCustomerByID( custid, lstCust);
            if (!IsPostBack)
            {
                //display the values of old customer
                DisplayCustValues();
            }
            
        }
        private void DisplayCustValues()
        {
            tbFirstName.Text = custov.CustFirstName;
            tbLastName.Text = custov.CustLastName;
            tbAddress.Text = custov.CustAddress;
            tbCity.Text = custov.CustCity;
           
            tbPostCode.Text = custov.CustPostalCode;
            tbCountry.Text = custov.CustCountry;
            tbHomePhone.Text = custov.CustHomePhone;
            tbBusPhone.Text = custov.CustBusPhone;
            tbEmail.Text = custov.CustEmail;
           
        }


      

       

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
           
                //get newcustomer value entered by user in customer object
                Customer CustNv = new Customer();
                CustNv.CustFirstName = tbFirstName.Text;
                CustNv.CustLastName = tbLastName.Text;
                CustNv.CustAddress = tbAddress.Text;
                CustNv.CustCity = tbCity.Text;
                CustNv.CustProv = ddlProvince.SelectedItem.Value;
                CustNv.CustPostalCode = tbPostCode.Text;
                CustNv.CustCountry = tbCountry.Text;
                CustNv.CustHomePhone = tbHomePhone.Text;
                CustNv.CustBusPhone = tbBusPhone.Text;
                CustNv.CustEmail = tbEmail.Text;
                CustNv.Password = tbPassword.Text;

                //apply update to the table

                if (CustomerDB.UpdateCustomer(custov, CustNv))
                {
                    Response.Redirect("Logout.aspx");

                }
                else
                {
                    lblErrorMessage.Text = "update Unsuccessful ";
                  
                }
           

        }
    }
}