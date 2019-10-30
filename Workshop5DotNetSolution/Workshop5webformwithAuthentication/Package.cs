using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


namespace Workshop5webformwithAuthentication
{
    public class Package
    {
        //class property
        public int PackageId { get; set; }
        public string PkgName { get; set; }
        public DateTime? PkgStartDate { get; set; }
        public DateTime? PkgEndDate { get; set; }

        public string PkgDesc { get; set; }

        public decimal PkgBasePrice { get; set; }
        public decimal? PkgAgencyCommission { get; set; }
        //method copy a Product
        public Package CopyPackage()
        {
            Package copy = new Package();
            copy.PackageId = PackageId; // this Package ID
            copy.PkgName = PkgName;
            copy.PkgStartDate = PkgStartDate;
            copy.PkgEndDate = PkgEndDate;
            copy.PkgDesc = PkgDesc;
            copy.PkgBasePrice = PkgBasePrice;
            copy.PkgAgencyCommission = PkgAgencyCommission;

            return copy;
        }

    }
}