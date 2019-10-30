using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Workshop5webformwithAuthentication
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CustEmail"] == null)
            {
                Session["LogIn"] = "Login";
                Session["Register"] = "Register";
            }
        }
    }
}