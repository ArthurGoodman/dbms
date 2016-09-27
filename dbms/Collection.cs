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
            return null;
        }

        public Document At(int i) {
            return documents[i];
        }
    }
}
