using System.Collections.Generic;

namespace dbms {
    public class Filter {
        private Dictionary<string, Variant> fields = new Dictionary<string, Variant>();

        public Filter(Dictionary<string, Variant> fields) {
            foreach (KeyValuePair<string, Variant> field in fields)
                Utility.ValidateName(field.Key);

            this.fields = fields;
        }

        public bool Match(Document document) {
            return true;
        }
    }
}
