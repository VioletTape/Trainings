namespace GoF_ShowCase.Builder.SimpleStructure {
    internal class Director {
        public void Construct(Builder builder) {
            builder.BuildPartA();
            builder.BuildPartB();
        }
    }
}