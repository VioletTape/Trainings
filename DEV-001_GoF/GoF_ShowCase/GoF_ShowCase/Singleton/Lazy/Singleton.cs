using System;

namespace GoF_ShowCase.Singleton.Lazy {
    /// <summary>Thread-safe .NET4 lazy singleton.</summary>
    public sealed class Singleton {
        private static readonly Lazy<Singleton> instance
            = new Lazy<Singleton>(() => new Singleton());

        private Singleton() {}

        public static Singleton Instance {
            get { return instance.Value; }
        }
    }
}