using System;

namespace GoF_ShowCase.Strategy.CryptExample {
    public interface IAlgorithm {
        string Crypt(String text, String key);
    }
}