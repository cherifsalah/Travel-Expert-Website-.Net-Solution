using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Workshop5webformwithAuthentication.App_Code
{
    public class Packages
    {       
            // prop for package name
            public string PkgName { get; set; }
            // prop for package start date
            public DateTime PkgStartDate { get; set; }
            // prop for package end date
            public DateTime PkgEndDate { get; set; }
            // prop for package description
            public string PkgDesc { get; set; }
            // prop for package base price
            public decimal PkgBasePrice { get; set; }
            // prop for package agency commission
            public decimal PkgAgencyCommission { get; set; }
            // prop for cost of all packages
            public decimal CostOfAllPackages { get; set; }
            // prop for count of packages bought
            public int CountOfPackagesBought { get; set; }
            // prop for cust First Name
            public string CustFirstName { get; set; }
            // prop for cust last name
            public string CustLastName { get; set; }
            // prop for Cust email
            public string CustEmail { get; set; }
       
    }
}