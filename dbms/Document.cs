using System.Collections.Generic;

namespace dbms {
    public class Document {
        private Dictionary<string, object> fields = new Dictionary<string, object>();

        public Document() {
        }

        public Document(Dictionary<string, object> fields) {
            foreach (KeyValuePair<string, object> field in fields)
                Utility.ValidateName(field.Key);

            this.fields = fields;
        }

        public bool Has(string name) {
            return fields.ContainsKey(name);
        }

        public object Get(string name) {
            return fields[name];
        }

        public void Set(string name, object value) {
            Utility.ValidateName(name);
            fields.Add(name, value);
        }

        public void Remove(string name) {
        }
    }
}
