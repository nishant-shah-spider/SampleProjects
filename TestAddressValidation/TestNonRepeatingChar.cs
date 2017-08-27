using FirstNonRepeatingChar;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAddressValidation
{
    [TestClass]
    public class TestNonRepeatingChar
    {
        [TestMethod]
        public void TestFirstNonRepeatingChar_OnlyOneRepeating()
        {
            string nonRepeatingChar = Program.GetFirstNonRepeatingChar("nishant");
            Assert.AreEqual("i", nonRepeatingChar, "Expected:- {0}. Actual is:- {1}", "i", nonRepeatingChar);
        }

        [TestMethod]
        public void TestFirstNonRepeatingChar_NoNonRepeatingChar()
        {
            string nonRepeatingChar = Program.GetFirstNonRepeatingChar("nnnnn");
            Assert.IsNull(nonRepeatingChar,"Expected was Null. But actual is:- "+nonRepeatingChar);
        }

        [TestMethod]
        public void TestFirstNonRepeatingChar_FirstCharisRepeating()
        {
            string nonRepeatingChar = Program.GetFirstNonRepeatingChar("ntnist");
            Assert.AreEqual("i", nonRepeatingChar, "Expected:- {0}. Actual is:- {1}", "i", nonRepeatingChar);
        }

        [TestMethod]
        public void TestFirstNonRepeatingChar_InputIsOnlySpaces()
        {
            string nonRepeatingChar = Program.GetFirstNonRepeatingChar("  ");
            Assert.IsNull(nonRepeatingChar, "Expected was Null. But actual is:- " + nonRepeatingChar);
        }
    }
}
