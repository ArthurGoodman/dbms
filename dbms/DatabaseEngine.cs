using System.Collections.Generic;

namespace dbms {
    public class DatabaseEngine {
        public Database db { get; private set; }
        private Dictionary<string, Database> databases = new Dictionary<string, Database>();

        public DatabaseEngine() {
            db = null;
        }

        public void Use(string name) {
            Utility.ValidateName(name);
        }

        public bool Contains(string name) {
            return true;
        }

        public void Drop(string name) {
        }
    }
}
