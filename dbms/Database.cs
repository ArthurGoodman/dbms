using System.Collections.Generic;

namespace dbms {
    public class Database {
        public string Name { get; private set; }
        public List<Collection> Collections { get; private set; }

        public Database(string name) {
            Name = name;
            Collections = new List<Collection>();
        }

        public void createCollection(string name) {
            Utility.ValidateName(name);
        }
    }
}
