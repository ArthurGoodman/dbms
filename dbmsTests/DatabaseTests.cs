using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace dbms.Tests {
    [TestClass()]
    public class DatabaseTests {
        [TestMethod()]
        public void ContainsTest() {
            Database db = new Database("test_db");

            Assert.IsFalse(db.Contains("test_collection"));
        }

        [TestMethod()]
        public void CollectionTest() {
            Database db = new Database("test_db");

            Assert.IsFalse(db.Contains("test_collection"));

            db.Collection("test_collection");

            Assert.IsTrue(db.Contains("test_collection"));
        }

        [TestMethod()]
        public void InsertTest() {
            Database db = new Database("test_db");
            Collection c = new Collection("test_collection");

            Assert.IsFalse(db.Contains("test_collection"));

            db.Insert(c);

            Assert.IsTrue(db.Contains("test_collection"));
            Assert.AreEqual(c, db.Collection("test_collection"));
        }

        [TestMethod()]
        public void RemoveTest() {
            Database db = new Database("test_db");
            db.Collection("test_collection");

            Assert.IsTrue(db.Contains("test_collection"));

            db.Remove("test_collection");

            Assert.IsFalse(db.Contains("test_collection"));
        }
    }
}
