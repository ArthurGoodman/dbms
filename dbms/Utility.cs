using System;

namespace dbms {
    public static class Utility {
        public static bool IsNameValid(string name) {
            return true;
        }

        public static void ValidateName(string name) {
            if (!IsNameValid(name))
                throw new Exception(string.Format("invalid name '{0}'", name));
        }
    }
}
