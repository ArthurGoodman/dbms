using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace dbms.Tests {
    [TestClass()]
    public class UtilityTests {
        [TestMethod()]
        public void ValidNameTest() {
            try {
                Utility.ValidateName("Valid_name.");
            } catch (Exception) {
                Assert.Fail();
            }
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidNameException))]
        public void InvalidNameTest() {
            Utility.ValidateName("Invalid name");
        }
    }
}
