using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SpecificationMain {
    [Serializable]
    public abstract class CompositeSpecification<T> : Specification<T> {
        protected readonly List<Specification<T>> specifications;

        public ReadOnlyCollection<Specification<T>> Specifications {
            get { return specifications.AsReadOnly(); }
        }

        protected CompositeSpecification(params Specification<T>[] specifications) {
            this.specifications = new List<Specification<T>>(specifications);
        }

        public CompositeSpecification<T> Add(Specification<T> specification) {
            specifications.Add(specification);
            return this;
        }

        public CompositeSpecification<T> Remove(Specification<T> specification) {
            specifications.Remove(specification);
            return this;
        }
    }
}