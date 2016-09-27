using System.Collections.Generic;

namespace dbms {
    public class Filter {
        private Dictionary<string, object> fields;

        public Filter(Dictionary<string, object> fields) {
            this.fields = fields;
        }

        public bool Match(Document document) {
            return true;
        }
    }
}
