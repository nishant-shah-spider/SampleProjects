using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressValidationTest
{
    public class WebServices
    {
        public Address FirstService(Address adr)
        {
            Address adr2 = new Address();
            adr2 = adr;
            adr2.Region = adr2.Region.Substring(0, 2).ToUpper();
            return adr2;

        }

        public Address SecondService(Address adr)
        {
            return adr;
        }
    }
}
