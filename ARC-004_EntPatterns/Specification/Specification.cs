using System;
using System.Linq;

namespace SpecificationMain {
    [Serializable]
    public abstract class Specification<T> {
        public static Specification<T> Null = new NullSpecification<T>();

        public static implicit operator Predicate<T>(Specification<T> specification) {
            return specification.IsSatisfiedBy;
        }

        public static Specification<T> operator |(Specification<T> left, Specification<T> right) {
            return new OrSpecification<T>(left, right);
        }

        public static Specification<T> operator &(Specification<T> left, Specification<T> right) {
            return new AndSpecification<T>(left, right);
        }

        public abstract bool IsSatisfiedBy(T obj);

        public TSpecification ExtractSupersetSpecification<TSpecification>() {
            return (TSpecification) (object) ExtractSpecification(typeof(TSpecification));
        }

        private Specification<T> ExtractSpecification(Type specificationType) {
            if (GetType() == specificationType) {
                return this;
            }

            if (this is AndSpecification<T>) {
                return ((AndSpecification<T>) this)
                    .Specifications
                    .Select(specification => specification.ExtractSpecification(specificationType))
                    .FirstOrDefault(superset => superset != null);
            }

            return null;
        }
    }
}