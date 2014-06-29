namespace GoF_TryOut.FactoryMethod.StraightCode {
    internal class Node {
        public bool IsCompany;
        public bool IsPerson;
        public bool IsNonProfitFoundation;

        public void Create(string url) {
            if (url.StartsWith("c:")) {
                IsCompany = true;
            }
            if (url.StartsWith("p:")) {
                IsPerson = true;
            }
            if (url.StartsWith("n:")) {
                IsNonProfitFoundation = true;
            }
        }


    }
}