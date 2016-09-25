using System;
using System.Linq;

namespace SpecificationMain {
    [Serializable]
    public class OrSpecification<T> : CompositeSpecification<T> {
        public OrSpecification(params Specification<T>[] specifications)
            : base(specifications) {}

        public override bool IsSatisfiedBy(T obj) {
            return specifications.Any(specification => specification.IsSatisfiedBy(obj));
        }
    }
}