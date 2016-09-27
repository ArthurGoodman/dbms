using System.Collections.Generic;

namespace dbms {
    public class Document {
        private Dictionary<string, Variant> fields = new Dictionary<string, Variant>();

        public Document() {
        }

        public Document(Dictionary<string, Variant> fields) {
            foreach (KeyValuePair<string, Variant> field in fields)
                Utility.ValidateName(field.Key);

            this.fields = fields;
        }

        public bool Has(string name) {
            return fields.ContainsKey(name);
        }

        public Variant Get(string name) {
            return fields[name];
        }

        public void Set(string name, Variant value) {
            Utility.ValidateName(name);
            fields.Add(name, value);
        }

        public void Remove(string name) {
        }
    }
}
