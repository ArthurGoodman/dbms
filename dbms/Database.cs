using System.Collections.Generic;

namespace dbms {
    public class Database {
        public string Name { get; private set; }
        private Dictionary<string, Collection> collections = new Dictionary<string, Collection>();

        public Database(string name) {
            Name = name;
        }

        public void Create(string name) {
            Utility.ValidateName(name);
        }

        public void Insert(string name, Collection collection) {
            Utility.ValidateName(name);
        }

        public bool Contains(string name) {
            return true;
        }

        public void Remove(string name) {
        }
    }
}
