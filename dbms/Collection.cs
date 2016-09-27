using System.Collections.Generic;

namespace dbms {
    public class Collection {
        private List<Document> documents = new List<Document>();

        public int Count {
            get {
                return documents.Count;
            }
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
    }
}
