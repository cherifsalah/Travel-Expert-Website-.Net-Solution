using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Workshop5webformwithAuthentication
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["logIn"] = "Login";
            Session["Register"] = "Register";
           
            
            //hide Detail
            Session["Detail"] = "";
            //hide booking
            Session["Booking"] = "";
            //hide logout
            Session["Logout"] = "";
            //hide update
            Session["Update"] = "";
            Response.Redirect("Default.aspx");
        }
    }
}