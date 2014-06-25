namespace GoF_ShowCase.Proxy.SimpleStructure {
    internal class Proxy : Subject {
        private RealSubject realSubject;

        public override void Request() {
            // Use 'lazy initialization' 
            if (realSubject == null) {
                realSubject = new RealSubject();
            }

            realSubject.Request();
        }
    }
}