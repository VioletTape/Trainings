using System;

namespace GoF_ShowCase.Strategy.CryptExample {
    public class Example {
        public  Example() {
            var key = "key";
            var text = "text";
            var encryption = new Encryption(new DesAlgorithm());
            var cryptedText = encryption.crypt(text, key);
        }
    }
}