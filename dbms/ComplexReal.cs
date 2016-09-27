namespace dbms {
    public struct ComplexReal {
        public double Re { get; set; }
        public double Im { get; set; }

        public ComplexReal(double re, double im) {
            Re = re;
            Im = im;
        }

        public override string ToString() {
            return string.Format("{0} + {1}i", Re, Im);
        }
    }
}
