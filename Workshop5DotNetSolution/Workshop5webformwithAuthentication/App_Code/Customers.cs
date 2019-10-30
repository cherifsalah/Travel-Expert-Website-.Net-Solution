using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Workshop5webformwithAuthentication.App_Code
{
    public class Customers
    {
        // Prop for CustomerID 
        public int CustomerID { get; set; }
        // Prop for Customer First Name
        public string CustFirstName { get; set; }
        // Prop for Customer Last name
        public string CustLastName { get; set; }
        // Prop for Customer Address
        public string CustAddress { get; set; }
        // Prop for Customer City
        public string CustCity { get; set; }
        // Prop for Customer Province 
        public string CustProv { get; set; }
        // Prop for Customer Postal Code 
        public string CustPostalCode { get; set; }
        // Prop for Customer Country 
        public string CustCountry { get; set; }
        // Prop for Customer Home phone number 
        public Int64? CustHomePhone { get; set; }
        // Prop for Customer Business phone number
        public Int64? CustBusPhone { get; set; }
        // Prop for Customer Email
        public string CustEmail { get; set; }
        // Prop for Customer Agent ID
        public int AgentID { get; set; }

        // Prop for Customer Password
        public string Password { get; set; }
    }
}