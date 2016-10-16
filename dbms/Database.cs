using System;
using System.Collections.Generic;

namespace dbms {
    [Serializable]
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
            return collections.ContainsKey(name);
        }

        public Collection Collection(string name) {
            if (Contains(name))
                return collections[name];
            else {
                Utility.ValidateName(name);

                Collection collection = new Collection(name);
                collections.Add(name, collection);
                return collection;
            }
        }

        public void Insert(Collection collection) {
            collections.Add(collection.Name, collection);
        }

        public void Remove(string name) {
            collections.Remove(name);
        }
    }
}
