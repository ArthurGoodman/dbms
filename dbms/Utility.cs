namespace dbms {
    public static class Utility {
        public static void ValidateName(string name) {
            if (!IsNameValid(name))
                throw new InvalidNameException(name);
        }

        private static bool IsNameValid(string name) {
            foreach (char c in name)
                if (!IsCharValid(c))
                    return false;

            return true;
        }

        private static bool IsCharValid(char c) {
            return char.IsLetter(c) || char.IsDigit(c) || c == '_' || c == '.';
        }
    }
}
