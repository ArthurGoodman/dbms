using System.Collections.Generic;

namespace dbms {
    public class DatabaseEngine {
        public Database db { get; private set; }
        private Dictionary<string, Database> databases = new Dictionary<string, Database>();

        public DatabaseEngine() {
            db = null;

            LoadData();
        }

        ~DatabaseEngine() {
            SaveData();
        }

        public void Use(string name) {
            Utility.ValidateName(name);

            if (Contains(name))
                db = databases[name];
            else {
                db = new Database(name);
                databases.Add(name, db);
            }
        }

        public bool Contains(string name) {
            return databases.ContainsKey(name);
        }

        public void Drop(string name) {
            databases.Remove(name);
        }

        private void LoadData() {
        }

        private void SaveData() {
        }
    }
}
