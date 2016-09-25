namespace GoF_ShowCase.Builder.SimpleStructure {
    internal abstract class Builder {
        public abstract void BuildPartA();
        public abstract void BuildPartB();
        public abstract Product GetResult();
    }
}