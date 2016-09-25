namespace GoF_ShowCase.Singleton.Subclass {
    /// <summary>Thread-safe singleton.</summary>
    public sealed class Singleton {
        private Singleton() {}

        public static Singleton Instance {
            get { return InstanceHolder.instance; }
        }

        private class InstanceHolder {
            static InstanceHolder() {}

            internal static readonly Singleton instance = new Singleton();
        }
    }
}