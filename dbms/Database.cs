using System.Collections.Generic;

namespace dbms {
    public class Database {
        public string Name { get; private set; }
        private Dictionary<string, Collection> collections = new Dictionary<string, Collection>();

        public int Size {
            get {
                return collections.Count;
            }
        }

        public Database(string name) {
            Utility.ValidateName(name);

            Name = name;
        }

        public bool Contains(string name) {
            return true;
        }

        public Collection Collection(string name) {
            return null;
        }

        public void Insert(Collection collection) {
        }

        public void Remove(string name) {
        }
    }
}
