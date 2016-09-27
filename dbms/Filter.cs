namespace dbms {
    public class Filter {
        private string[] names;

        public Filter(params string[] names) {
            this.names = names;
        }

        public bool Match(Document document) {
            return true;
        }
    }
}
