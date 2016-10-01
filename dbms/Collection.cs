using System.Collections.Generic;
using System.Linq;

namespace dbms {
    public class Collection {
        public string Name { get; private set; }
        private List<Document> documents = new List<Document>();

        public int Size {
            get {
                return documents.Count;
            }
        }

        public Collection(string name) {
            Utility.ValidateName(name);

            Name = name;
        }

        private Collection(List<Document> documents) {
            this.documents = documents;
        }

        public void Insert(Document document) {
            documents.Add(document);
        }

        public void Update(Filter filter, Document document) {
            foreach (Document doc in documents)
                if (filter == null || filter.Match(doc))
                    doc.Assign(document);
        }

        public void Remove(Filter filter) {
            documents.RemoveAll(doc => filter == null || filter.Match(doc));
        }

        public Collection Select(Filter filter) {
            Collection collection = new Collection(documents.Where(doc => filter == null || filter.Match(doc)).ToList());
            collection.Name = collection.GetHashCode().ToString("x");
            return collection;
        }

        public Collection Join(Collection other, string field) {
            Collection result = new Collection(string.Format("{0}_{1}", Name, other.Name));

            for (int i = 0; i < Size; i++) {
                Document doc = At(i);

                if (doc.Has(field)) {
                    Collection match = other.Select(new Filter(new Dictionary<string, Variant>() { { field, doc.Get(field) } }));

                    for (int j = 0; j < match.Size; j++)
                        result.Insert(doc.Join(match.At(j), Name, other.Name));
                }
            }

            return result;
        }

        public void Sort(string key) {
            documents.Sort((doc1, doc2) => doc1.Get(key).CompareTo(doc2.Get(key)));
        }

        public Document At(int i) {
            return documents[i];
        }
    }
}
