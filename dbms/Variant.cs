using System;
using System.Drawing;

namespace dbms {
    public class Variant {
        public enum ValueType {
            Null,
            Int,
            Real,
            String,
            ComplexInteger,
            ComplexReal,
            Bitmap,
            RealInterval
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

        public Variant(Bitmap value) {
            Value = value;
            Type = ValueType.Bitmap;
        }

        public Variant(RealInterval value) {
            Value = value;
            Type = ValueType.RealInterval;
        }

        public override bool Equals(object obj) {
            if (obj is Variant)
                return Value.Equals(((Variant)obj).Value);

            return false;
        }

        public override int GetHashCode() {
            return Value.GetHashCode();
        }

        public override string ToString() {
            return Value.ToString();
        }

        public int CompareTo(Variant other) {
            if (Type != other.Type)
                InvalidComparison();

            switch (Type) {
                case ValueType.Int:
                    return ((int)Value).CompareTo((int)other.Value);
                case ValueType.Real:
                    return ((double)Value).CompareTo((double)other.Value);
                case ValueType.String:
                    return ((string)Value).CompareTo((string)other.Value);
            }

            InvalidComparison();
            return 0;
        }

        private static void InvalidComparison() {
            throw new Exception("Invalid comparison");
        }
    }
}
