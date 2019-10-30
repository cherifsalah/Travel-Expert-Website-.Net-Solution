using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


namespace Workshop5webformwithAuthentication
{
    public class PackagesDB
    {
        // This function gets all the packages
        //Get a list of all packages in the Db 
        public static List<Package> GetPackages()
        {
            List<Package> lstresult = new List<Package>();//
            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string selectQuery = "SELECT PackageId, PkgName, PkgStartDate, PkgEndDate, PkgDesc, PkgBasePrice, " +
                                     " PkgAgencyCommission FROM Packages";

                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    //test if there is packages 
                    if (reader.HasRows)
                    {
                        int col_PkgStartDate = reader.GetOrdinal("PkgStartDate");
                        int col_PkgEndDate = reader.GetOrdinal("PkgEndDate");
                        int col_PkgDesc = reader.GetOrdinal("PkgDesc");
                        int col_PkgAgencyCommission = reader.GetOrdinal("PkgAgencyCommission");
                        //create a package and add it to the list
                        while (reader.Read())
                        {
                            Package package = new Package();
                            package.PackageId = (int)reader["PackageId"];
                            package.PkgName = (string)reader["PKgName"];

                            package.PkgStartDate = reader.IsDBNull(col_PkgStartDate) ?
                                     null : (DateTime?)reader["PkgStartDate"];
                            package.PkgEndDate = reader.IsDBNull(col_PkgEndDate) ?
                                     null : (DateTime?)reader["PkgEndDate"];
                            package.PkgDesc = reader.IsDBNull(col_PkgDesc) ?
                                     null : (string)reader["PkgDesc"];

                            package.PkgBasePrice = (decimal)reader["PkgBasePrice"];
                            package.PkgAgencyCommission = reader.IsDBNull(col_PkgAgencyCommission) ?
                                     null : (decimal?)reader["PkgAgencyCommission"];

                            lstresult.Add(package);
                        }
                    }

                }
            }

            return lstresult;
        }
        //get the Package Id of a given Package name
        public static int GetPkgIdByPkgName(string PkgName,List<Package> lstPkg)
        {
            int pkgid=0;
            foreach (Package pkg in lstPkg)
            {
                if (pkg.PkgName == PkgName)
                {
                    pkgid= pkg.PackageId;
                    break;
                }
            }
            return pkgid;
        }

    }
}