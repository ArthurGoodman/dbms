using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace dbms.Tests {
    [TestClass()]
    public class DocumentTests {
        [TestMethod()]
        public void HasTest() {
            Document doc = new Document();

            Assert.IsFalse(doc.Has("test"));
        }

        [TestMethod()]
        public void GetTest() {
            Document doc = new Document();
            Variant var = new Variant();
            doc.Set("test", var);

            Assert.AreEqual(var, doc.Get("test"));
        }

        [TestMethod()]
        public void SetTest() {
            Document doc = new Document();
            
            Assert.IsFalse(doc.Has("test"));

            doc.Set("test", null);

            Assert.IsTrue(doc.Has("test"));
        }

        [TestMethod()]
        public void RemoveTest() {
            Document doc = new Document();
            doc.Set("test", null);

            Assert.IsTrue(doc.Has("test"));

            doc.Remove("test");

            Assert.IsFalse(doc.Has("test"));
        }
    }
}
