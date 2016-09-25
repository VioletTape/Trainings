namespace GoF_ShowCase.Singleton.Static {
    public class Singleton {
        private static Singleton instance;

        // Note: Constructor is 'protected' 
        protected Singleton() {}

        public static Singleton Instance() {
            if (instance == null) {
                instance = new Singleton();
            }

            return instance;
        }
    }


    public class Singleton1 {
        private static readonly Singleton1 instance = new Singleton1();

        // Note: Constructor is 'protected' 
        protected Singleton1() {}

        public static Singleton1 Instance() {
            return instance;
        }
    }
}