using System.Collections.Generic;

namespace dbms {
    public class DatabaseEngine {
        public Database db { get; private set; }
        public List<Database> Databases { get; private set; }

        public DatabaseEngine() {
            db = null;
            Databases = new List<Database>();
        }

        public void Use(string name) {
            Utility.ValidateName(name);
        }

        public void Drop(string name) {
            Utility.ValidateName(name);
        }
    }
}
