using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressValidationTest
{
    class WebServices
    {
        public Address FirstService(Address addr)
        {
            addr.Region = addr.Region.Substring(0, 2).ToUpper();
            return addr;

        }

        public Address SecondService(Address addr)
        {
            return addr;
        }
    }
}
