using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

namespace dbms.Tests {
    [TestClass()]
    public class DatabaseEngineTests {
        [TestMethod()]
        public void UseTest() {
            File.Delete(DatabaseEngine.FileName);

            DatabaseEngine engine = new DatabaseEngine();

            Assert.AreEqual(null, engine.db);

            engine.Use("test_db");

            Assert.AreEqual("test_db", engine.db.Name);

            File.Delete(DatabaseEngine.FileName);
        }

        [TestMethod()]
        public void DropTest() {
            File.Delete(DatabaseEngine.FileName);

            DatabaseEngine engine = new DatabaseEngine();
            engine.Use("test_db");

            Assert.IsTrue(engine.Contains("test_db"));

            engine.Drop("test_db");

            Assert.IsFalse(engine.Contains("test_db"));

            File.Delete(DatabaseEngine.FileName);
        }

        [TestMethod()]
        public void SerializationTest() {
            File.Delete(DatabaseEngine.FileName);

            DatabaseEngine engine = new DatabaseEngine();
            engine.Use("test_db");

            Collection c = engine.db.Collection("test_collection");
            c.Insert(new Document(new Dictionary<string, Variant>() { { "test", new Variant("test_value") } }));

            engine.SaveData();

            engine = new DatabaseEngine();
            engine.Use("test_db");

            Assert.AreEqual(new Variant("test_value"), engine.db.Collection("test_collection").At(0).Get("test"));

            File.Delete(DatabaseEngine.FileName);
        }
    }
}
