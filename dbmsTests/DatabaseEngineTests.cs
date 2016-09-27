using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace dbms.Tests {
    [TestClass()]
    public class DatabaseEngineTests {
        [TestMethod()]
        public void UseTest() {
            DatabaseEngine engine = new DatabaseEngine();

            Assert.AreEqual(null, engine.db);

            engine.Use("test_db");

            Assert.AreEqual("test_db", engine.db.Name);
        }

        [TestMethod()]
        public void DropTest() {
            DatabaseEngine engine = new DatabaseEngine();
            engine.Use("test_db");

            Assert.IsTrue(engine.Contains("test_db"));

            engine.Drop("test_db");

            Assert.IsFalse(engine.Contains("test_db"));
        }
    }
}
