using System.Collections.Generic;

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

        public void Insert(Document document) {
        }

        public void Update(Filter filter, Document document) {
        }

        public void Remove(Filter filter) {
        }

        public Collection Select(Filter filter) {
            return null;
        }

        public Collection Join(Collection other, string field) {
            return null;
        }

        public Document At(int i) {
            return documents[i];
        }
    }
}
