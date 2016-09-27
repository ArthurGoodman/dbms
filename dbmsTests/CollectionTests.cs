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
            c.Insert(new Document(new Dictionary<string, Variant>() { { "test", new Variant(0) } }));
            c.Update(null, new Document(new Dictionary<string, Variant>() { { "test", new Variant(1) } }));

            Assert.AreEqual(new Variant(1), c.Select(null).At(0).Get("test"));
        }

        [TestMethod()]
        public void RemoveTest() {
            Collection c = new Collection("test_collection");
            c.Insert(new Document(new Dictionary<string, Variant>() { { "test", new Variant(0) } }));

            Assert.AreEqual(1, c.Size);

            c.Remove(new Filter(new Dictionary<string, Variant>() { { "test", new Variant(0) } }));

            Assert.AreEqual(0, c.Size);
        }

        [TestMethod()]
        public void SelectTest() {
            Collection c = new Collection("test_collection");
            c.Insert(new Document(new Dictionary<string, Variant>() { { "id", new Variant(1) }, { "test", new Variant("one") } }));
            c.Insert(new Document(new Dictionary<string, Variant>() { { "id", new Variant(2) }, { "test", new Variant("two") } }));
            c.Insert(new Document(new Dictionary<string, Variant>() { { "id", new Variant(3) }, { "test", new Variant("three") } }));

            Assert.AreEqual(new Variant("two"), c.Select(new Filter(new Dictionary<string, Variant>() { { "id", new Variant(2) } })).At(0).Get("test"));
        }

        [TestMethod()]
        public void JoinTest() {
            Collection a = new Collection("a");
            a.Insert(new Document(new Dictionary<string, Variant>() { { "id", new Variant(0) }, { "test", new Variant(11) } }));
            a.Insert(new Document(new Dictionary<string, Variant>() { { "id", new Variant(1) }, { "test", new Variant(22) } }));
            a.Insert(new Document(new Dictionary<string, Variant>() { { "id", new Variant(2) }, { "test", new Variant(33) } }));

            Collection b = new Collection("b");
            b.Insert(new Document(new Dictionary<string, Variant>() { { "id", new Variant(3) }, { "test", new Variant(44) } }));
            b.Insert(new Document(new Dictionary<string, Variant>() { { "id", new Variant(0) }, { "test", new Variant(55) } }));
            b.Insert(new Document(new Dictionary<string, Variant>() { { "id", new Variant(4) }, { "test", new Variant(66) } }));

            Assert.AreEqual(new Variant(11), a.Join(b, "id").At(0).Get("a.test"));
            Assert.AreEqual(new Variant(55), a.Join(b, "id").At(0).Get("b.test"));
        }

        [TestMethod()]
        public void AtTest() {
            Collection c = new Collection("test_collection");
            c.Insert(new Document(new Dictionary<string, Variant>() { { "test", new Variant(11) } }));
            c.Insert(new Document(new Dictionary<string, Variant>() { { "test", new Variant(22) } }));
            c.Insert(new Document(new Dictionary<string, Variant>() { { "test", new Variant(33) } }));
            c.Insert(new Document(new Dictionary<string, Variant>() { { "test", new Variant(44) } }));
            c.Insert(new Document(new Dictionary<string, Variant>() { { "test", new Variant(55) } }));

            Assert.AreEqual(new Variant(44), c.At(3).Get("test"));
        }
    }
}
