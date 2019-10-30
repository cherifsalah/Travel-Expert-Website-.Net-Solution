using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Workshop5webformwithAuthentication
{
    public partial class Booking : System.Web.UI.Page
    {
        List<Package> lstPackages = null;
        List<Customer> lstCustomers = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            //get all packages in the system
            lstPackages = PackagesDB.GetPackages();
            lstCustomers = CustomerDB.GetCustomers();
        }

        protected void GridViewBooking_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get slipid of row selected
            if (GridViewBooking.SelectedIndex > -1)
            {
                //get the id from the row selected
                var selectedrow = GridViewBooking.SelectedRow;
                //get pkgname
                string Pkgname = selectedrow.Cells[0].Text;
                //get travelercount
               float  travelercount = Convert.ToSingle(tbTravelerCount.Text);
                //get trip type ID
                string tripTypeId = ddlisttripType.SelectedItem.Value;
                //get Package ID 
                int PkgID = PackagesDB.GetPkgIdByPkgName( Pkgname,lstPackages);
                //get Customer ID from customer email
                string Custemail = Session["CustEmail"].ToString();
                int CustID = CustomerDB.GetCustomerIDByEmail( Custemail, lstCustomers);
                //get booking date
                DateTime dateoftoday = DateTime.Now;
                //get booking N
                string BookingNo = "BB4545" ;
                SqlConnection con = TravelExpertsDB.GetConnection();
                //add a row to the booking table with the information entered by user for this customer ID 
                string insertStatement = "INSERT INTO Bookings (BookingDate,BookingNo,TravelerCount,CustomerId,TripTypeId,PackageId) " +
                                         "VALUES(@BookingDate,@BookingNo,@TravelerCount,@CustomerId,@TripTypeId,@PackageId)";
                SqlCommand cmd = new SqlCommand(insertStatement, con);
                cmd.Parameters.AddWithValue("@BookingDate", dateoftoday);
                cmd.Parameters.AddWithValue("@BookingNo", BookingNo);
                cmd.Parameters.AddWithValue("@TravelerCount", travelercount);
                cmd.Parameters.AddWithValue("@CustomerId", CustID);
                cmd.Parameters.AddWithValue("@TripTypeId", tripTypeId);
                cmd.Parameters.AddWithValue("@PackageId", PkgID);
                
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery(); // run the insert command
                                           // get the generated ID - current identity value for  booking table
                    string selectQuery = "SELECT IDENT_CURRENT('Bookings') FROM Bookings";
                    SqlCommand selectCmd = new SqlCommand(selectQuery, con);
                    int BookingID = Convert.ToInt32(selectCmd.ExecuteScalar()); // single value
                                                                              // typecase (int) does NOT work!
                                                                              //change button text from select to succefuly leased
                    lblbokingConfirmation.Text = "Your booking for Package Num: "+ PkgID.ToString()+ " has been successful. Your Booking No is " + BookingNo +
                        " An Agent will get in touch with you within 24 Hours to Process the payment";
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}