using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace AddressValidationTest
{
    class Core
    {
        string connectionString = null;
        SqlConnection connection = null;
        Address addr = new Address();
        WebServices ws = new WebServices();
        public Core()
        {
            connectionString = new SqlConnection(ConfigurationManager.ConnectionStrings["Test"].ConnectionString).ToString();
        }


        /// <summary>
        /// Fetching the address from the Address table containing 2 million records
        /// </summary>
        public void FetchAddressAndCompare()
        {
             
             string sqlQuery = "Select AddressLine, AddressLine2, AddressLine3, City, Country, Region, PostalCode from Address";
            try
            {
                SqlConnection.ClearAllPools();
                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                    {
                        var dr = cmd.ExecuteReader();   
                        while (dr.Read())
                        {
                          addr.Line1 = dr.GetString(0);
                          addr.Line2 = dr.GetString(1);
                          addr.Line3 = dr.GetString(2);
                          addr.City = dr.GetString(3);
                          addr.Country = dr.GetString(4);
                          addr.Region = dr.GetString(5);
                          addr.PostalCode = dr.GetString(6);

                          CompareAPIResults();

                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("There was a problem while reading " + e);
            }
            finally
            {
               if (connection != null && connection.State != System.Data.ConnectionState.Closed) connection.Close();
            }
            
        }

        /// <summary>
        /// Inserting the results into the DB
        /// </summary>
        /// <param name="addrWebService1"></param>
        /// <param name="addrWebService2"></param>
        /// <param name="difference"></param>
        public void InsertResultsIntoDB(String addrWebService1, String addrWebService2, String difference)
        {
            string insertString = "Insert into Results (AddressWebService1,AddressWebService2,Difference)" +
                                      "Values" +
                                      "(@AddressWebService1,@AddressWebService2,@Difference)";
                using (SqlCommand cmd = new SqlCommand(insertString, connection))
                {
                    cmd.Parameters.Add("@AddressWebService1", SqlDbType.NVarChar).Value = addrWebService1;
                    cmd.Parameters.Add("@AddressWebService1", SqlDbType.NVarChar).Value = addrWebService2;
                    cmd.Parameters.Add("@AddressWebService1", SqlDbType.NVarChar).Value = difference;
                    cmd.ExecuteNonQuery();
                }
                        
          
        }

        /// <summary>
        /// Compares the results of two API's And Triggers the Insert Function
        /// </summary>
        public void CompareAPIResults()
        {
           try
           {
               Address addrwebService1 = new Address();
               Address addrwebService2 = new Address();
               StringBuilder differenceDetails = new StringBuilder();

               addrwebService1 = ws.FirstService(addr);
               addrwebService2 = ws.SecondService(addr);

               string fullAddressOfWebService1 = addrwebService1.Line1+" "+addrwebService1.Line2+" "+addrwebService1.Line3+" "+
                                                 addrwebService1.City+" "+addrwebService1.Country+" "+addrwebService1.Region+" "+
                                                 addrwebService1.PostalCode;

              string fullAddressOfWebService2 = addrwebService2.Line1+" "+addrwebService2.Line2+" "+addrwebService2.Line3+" "+
                                                 addrwebService2.City+" "+addrwebService2.Country+" "+addrwebService2.Region+" "+
                                                 addrwebService2.PostalCode;

               //Comparing each Address attribute of both Webservices
               if(!addrwebService1.Line1.ToUpper().Equals(addrwebService2.Line1.ToUpper()))
               {
                   differenceDetails.Append("Line1 for WebService1:-" + addrwebService1.Line1 + ". Line1 for WebService2:-" + addrwebService2.Line1);
               }

               if (!addrwebService1.Line2.ToUpper().Equals(addrwebService2.Line2.ToUpper()))
               {
                   differenceDetails.Append("Line2 for WebService1:-" + addrwebService1.Line2 + ". Line2 for WebService2:-" + addrwebService2.Line2);
               }

               if (!addrwebService1.Line3.ToUpper().Equals(addrwebService2.Line3.ToUpper()))
               {
                   differenceDetails.Append("Line3 for WebService1:-" + addrwebService1.Line3 + ". Line3 for WebService2:-" + addrwebService2.Line3);
               }

               if (!addrwebService1.Country.ToUpper().Equals(addrwebService2.Country.ToUpper()))
               {
                   differenceDetails.Append("Country for WebService1:-" + addrwebService1.Country + ". Country for WebService2:-" + addrwebService2.Country);
               }

               if (!addrwebService1.City.ToUpper().Equals(addrwebService2.City.ToUpper()))
               {
                   differenceDetails.Append("City for WebService1:-" + addrwebService1.City + ". City for WebService2:-" + addrwebService2.City);
               }

               if (!addrwebService1.Region.ToUpper().Equals(addrwebService2.Region.ToUpper()))
               {
                   differenceDetails.Append("Region for WebService1:-" + addrwebService1.Region + ". Region for WebService2:-" + addrwebService2.Region);
               }

               if (!addrwebService1.PostalCode.ToUpper().Equals(addrwebService2.PostalCode.ToUpper()))
               {
                   differenceDetails.Append("PostalCode for WebService1:-" + addrwebService1.PostalCode + ". PostalCode for WebService2:-" + addrwebService2.PostalCode);
               }

               //Inserting the result into a new table
               InsertResultsIntoDB(fullAddressOfWebService1, fullAddressOfWebService2, differenceDetails.ToString());
               
           }
           catch (Exception e)
           {

           }
        }
        
    }
}
