using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace dbms.Tests {
    [TestClass()]
    public class CollectionTests {
        [TestMethod()]
        public void InsertTest() {
            Collection c = new Collection("test_collection");

            for (int i = 0; i < 3; i++)
                c.Insert(new Document());

            Assert.AreEqual(c.Size, 3);
        }

        [TestMethod()]
        public void UpdateTest() {
            Collection c = new Collection("test_collection");
            c.Insert(new Document(new Dictionary<string, object>() { { "test", 0 } }));
            c.Update(new Filter(new Dictionary<string, object>() { { "test", 0 } }), new Document(new Dictionary<string, object>() { { "test", 1 } }));

            Assert.AreEqual(1, c.Select(new Filter(new Dictionary<string, object>() { { "test", 0 } })).At(0).Get("test"));
        }

        [TestMethod()]
        public void RemoveTest() {
            Collection c = new Collection("test_collection");
            c.Insert(new Document(new Dictionary<string, object>() { { "test", 0 } }));

            Assert.AreEqual(1, c.Size);

            c.Update(new Filter(new Dictionary<string, object>() { { "test", 0 } }), new Document(new Dictionary<string, object>() { { "test", 1 } }));

            Assert.AreEqual(0, c.Size);
        }

        [TestMethod()]
        public void SelectTest() {
            Collection c = new Collection("test_collection");
            c.Insert(new Document(new Dictionary<string, object>() { { "test", 0 } }));

            Assert.AreEqual(0, c.Select(new Filter(new Dictionary<string, object>() { { "test", 0 } })).At(0).Get("test"));
        }

        [TestMethod()]
        public void JoinTest() {
            Collection a = new Collection("a");
            a.Insert(new Document(new Dictionary<string, object>() { { "id", 0 }, { "test", 11 } }));
            a.Insert(new Document(new Dictionary<string, object>() { { "id", 1 }, { "test", 22 } }));
            a.Insert(new Document(new Dictionary<string, object>() { { "id", 2 }, { "test", 33 } }));

            Collection b = new Collection("b");
            b.Insert(new Document(new Dictionary<string, object>() { { "id", 3 }, { "test", 44 } }));
            b.Insert(new Document(new Dictionary<string, object>() { { "id", 0 }, { "test", 55 } }));
            b.Insert(new Document(new Dictionary<string, object>() { { "id", 4 }, { "test", 66 } }));

            Assert.AreEqual(11, a.Join(b, "id").At(0).Get("a.test"));
            Assert.AreEqual(55, a.Join(b, "id").At(0).Get("b.test"));
        }
    }
}
