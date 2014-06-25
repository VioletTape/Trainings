using System;

namespace GoF_ShowCase.Strategy.CryptExample {
    public class Encryption {
        private readonly IAlgorithm algorithm;

        public IAlgorithm Algorithm { get; set; }

        public Encryption(IAlgorithm algorithm) {
            this.algorithm = algorithm;
        }

        public string crypt(String text, String key) {
            return algorithm.Crypt(text, key);
        }
    }
}