using System;

namespace SpecificationMain {
    [Serializable]
    public class NullSpecification<T> : Specification<T> {
        public override bool IsSatisfiedBy(T obj) {
            return true;
        }
    }
}