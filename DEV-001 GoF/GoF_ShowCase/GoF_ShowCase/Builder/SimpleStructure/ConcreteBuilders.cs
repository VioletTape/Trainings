namespace GoF_ShowCase.Builder.SimpleStructure {
    internal class ConcreteBuilder1 : Builder {
        private readonly Product product = new Product();

        public override void BuildPartA() {
            product.Add("PartA");
        }

        public override void BuildPartB() {
            product.Add("PartB");
        }

        public override Product GetResult() {
            return product;
        }
    }

    internal class ConcreteBuilder2 : Builder {
        private readonly Product product = new Product();

        public override void BuildPartA() {
            product.Add("PartX");
        }

        public override void BuildPartB() {
            product.Add("PartY");
        }

        public override Product GetResult() {
            return product;
        }
    }
}