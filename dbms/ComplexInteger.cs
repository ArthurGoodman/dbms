namespace dbms {
    public struct ComplexInteger {
        public int Re { get; set; }
        public int Im { get; set; }

        public ComplexInteger(int re, int im) {
            Re = re;
            Im = im;
        }

        public override string ToString() {
            return string.Format("{0} + {1}i", Re, Im);
        }
    }
}
