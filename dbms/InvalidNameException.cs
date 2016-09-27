using System;

namespace dbms {
    public class InvalidNameException : Exception {
        public InvalidNameException(string name) : base(string.Format("Invalid name '{0}'", name)) {
        }
    }
}
