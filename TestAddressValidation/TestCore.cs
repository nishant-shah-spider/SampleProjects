using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddressValidationTest;

namespace TestAddressValidation
{
    [TestClass]
    public class Testcr
    {

        Core cr = new Core();

        [TestMethod]
        public void TestCompareAPIResults_When_Returns_SameAddresses()
        {
           
            cr.addr.Line1 = "700 Pik Street";
            cr.addr.Line2 = "Avalara";
            cr.addr.Line3 = "";
            cr.addr.City = "Seattle";
            cr.addr.Country = "US";
            cr.addr.Region = "WA";
            cr.addr.PostalCode = "98110-2311";

            cr.CompareAPIResults();

            Assert.IsTrue(cr.differenceDetails.ToString().Equals(String.Empty),
                "There is some difference in the response when there should not be any." +
                "The difference is in: " + cr.differenceDetails.ToString());
        }

        [TestMethod]
        public void TestCompareAPIResults_When_Returns_DifferentRegions()
        {
            cr.addr.Line1 = "700 Pik Street";
            cr.addr.Line2 = "Avalara";
            cr.addr.Line3 = "";
            cr.addr.City = "Seattle";
            cr.addr.Country = "US";
            cr.addr.Region = "Washington";
            cr.addr.PostalCode = "98110-2311";

            cr.CompareAPIResults();

            Assert.IsTrue(cr.differenceDetails.ToString().ToUpper().Contains(cr.addrwebService2.Region.ToUpper()),
                "The region of webservice1 : {0}" + "is not displayed in the DifferenceDetails string", cr.addrwebService2.Region.ToUpper());

            Assert.IsTrue(cr.differenceDetails.ToString().ToUpper().Contains(cr.addrwebService1.Region.ToUpper()),
               "The region of webservice2 : {0}" + "is not displayed in the DifferenceDetails string", cr.addrwebService1.Region.ToUpper());
        }

        [TestMethod]
        public void TestCompareAPIResults_When_Returns_DifferentRegionAndPostalCode()
        {
            cr.addr.Line1 = "700 Pik Street";
            cr.addr.Line2 = "Avalara";
            cr.addr.Line3 = "";
            cr.addr.City = "Seattle";
            cr.addr.Country = "US";
            cr.addr.Region = "Washington";
            cr.addr.PostalCode = "98110";

            cr.CompareAPIResults();

            Assert.IsTrue(cr.differenceDetails.ToString().Contains(cr.addrwebService1.Region),
                "The region of webservice1 : {0}" + "is not displayed in the DifferenceDetails string", cr.addrwebService1.Region);

            Assert.IsTrue(cr.differenceDetails.ToString().Contains(cr.addrwebService2.Region),
               "The region of webservice2 : {0}" + "is not displayed in the DifferenceDetails string", cr.addrwebService2.Region);

            Assert.IsTrue(cr.differenceDetails.ToString().Contains(cr.addrwebService1.PostalCode),
              "The postal code of webservice1 : {0}" + "is not displayed in the DifferenceDetails string", cr.addrwebService1.PostalCode);

            Assert.IsTrue(cr.differenceDetails.ToString().Contains(cr.addrwebService2.PostalCode),
               "The postal code of webservice2 : {0}" + "is not displayed in the DifferenceDetails string", cr.addrwebService2.PostalCode);
        }
    }
}
