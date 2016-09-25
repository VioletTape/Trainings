namespace SpecificationMain {
    public class Top<T> : Specification<T> {
        public int NumberOfRecords { get; private set; }

        public Top(int numberOfRecords) {
            NumberOfRecords = numberOfRecords;
        }

        public override bool IsSatisfiedBy(T obj) {
            return true;
        }
    }
}