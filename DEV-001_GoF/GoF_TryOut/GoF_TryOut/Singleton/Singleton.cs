using System;

namespace GoF_TryOut.Singleton {
    public class MySingleton {
        private readonly object lockObj = new object();
        private MySingleton instance;

        private MySingleton() {}

        public MySingleton GetInstance() {
            if (instance == null)
                lock (lockObj) {
                    if (instance == null)
                        instance = new MySingleton();
                }


            return instance;
        }
    }

    public class LazySingleton {
        // static holder for instance, need to use lambda to construct since constructor private
        private static readonly Lazy<LazySingleton> instance
            = new Lazy<LazySingleton>(() => new LazySingleton());

        // private to prevent direct instantiation.
        private LazySingleton() {}

        // accessor for instance
        public static LazySingleton Instance {
            get { return instance.Value; }
        }
    }
}