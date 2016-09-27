namespace dbms {
    public class Variant {
        public enum ValueType {
            Null,
            Int,
            Real,
            String,
            ComplexInteger,
            ComplexReal
        };

        public object Value { get; private set; }
        public ValueType Type { get; private set; }

        public Variant() {
            Value = null;
            Type = ValueType.Null;
        }

        public Variant(int value) {
            Value = value;
            Type = ValueType.Int;
        }

        public Variant(double value) {
            Value = value;
            Type = ValueType.Real;
        }

        public Variant(string value) {
            Value = value;
            Type = ValueType.String;
        }

        public Variant(ComplexInteger value) {
            Value = value;
            Type = ValueType.ComplexInteger;
        }

        public Variant(ComplexReal value) {
            Value = value;
            Type = ValueType.ComplexReal;
        }

        public override bool Equals(object obj) {
            return Value.Equals(obj);
        }

        public override int GetHashCode() {
            return Value.GetHashCode();
        }

        public override string ToString() {
            return Value.ToString();
        }
    }
}
