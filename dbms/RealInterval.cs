namespace dbms {
    public struct RealInterval {
        public double Start { get; set; }
        public double End { get; set; }

        public RealInterval(double start, double end) {
            Start = start;
            End = end;
        }

        public override string ToString() {
            return string.Format("[{0}, {1}]", Start, End);
        }
    }
}
