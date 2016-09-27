using System.Collections.Generic;

namespace dbms {
    public class Document {
        private Dictionary<string, object> values = new Dictionary<string, object>();

        public bool Has(string name) {
            return values.ContainsKey(name);
        }

        public object Get(string name) {
            return values[name];
        }

        public void Set(string name, object value) {
            Utility.ValidateName(name);
            values.Add(name, value);
        }
    }
}
