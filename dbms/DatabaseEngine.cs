using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace dbms {
    public class DatabaseEngine {
        public static string FileName { get { return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\databases"; } }

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

        public void LoadData() {
            if (!File.Exists(FileName))
                return;

            FileStream stream = File.OpenRead(FileName);

            try {
                BinaryFormatter formatter = new BinaryFormatter();
                databases = (Dictionary<string, Database>)formatter.Deserialize(stream);
            } finally {
                stream.Close();
            }
        }

        public void SaveData() {
            if (File.Exists(FileName))
                File.Delete(FileName);

            FileStream stream = File.Create(FileName);

            try {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, databases);
            } finally {
                stream.Close();
            }
        }
    }
}
