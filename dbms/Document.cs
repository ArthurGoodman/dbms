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

            if (Has(name))
                fields[name] = value;
            else
                fields.Add(name, value);
        }

        public void Remove(string name) {
            fields.Remove(name);
        }

        public void Assign(Document document) {
            foreach (KeyValuePair<string, Variant> field in document.fields)
                Set(field.Key, field.Value);
        }

        public Document Join(Document document, string leftName, string rightName) {
            Document result = new Document();

            foreach (KeyValuePair<string, Variant> field in fields) {
                result.Set(string.Format("{0}.{1}", leftName, field.Key), field.Value);
                result.Set(string.Format("{0}.{1}", rightName, field.Key), document.Get(field.Key));
            }

            return result;
        }
    }
}
