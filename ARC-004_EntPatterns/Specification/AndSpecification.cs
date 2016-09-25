using System;
using System.Linq;

namespace SpecificationMain {
    [Serializable]
    public class AndSpecification<T> : CompositeSpecification<T> {
        public AndSpecification(params Specification<T>[] specifications)
            : base(specifications) {}

        public override bool IsSatisfiedBy(T obj) {
            return specifications.All(specification => specification.IsSatisfiedBy(obj));
        }
    }
}