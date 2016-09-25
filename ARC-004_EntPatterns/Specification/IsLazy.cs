using System;
using System.Collections.Generic;

namespace SpecificationMain {
    [Serializable]
    public class IsLazy<T> : NullSpecification<T> {
        private List<Type> lazyTypes = new List<Type>();

        public List<Type> LazyTypes {
            get { return new List<Type>(lazyTypes); }
        }

        public IsLazy<T> WithLazy<TLazyType>() {
            lazyTypes.Add(typeof(TLazyType));
            return this;
        }

        public IsLazy<ToType> For<ToType>() {
            return new IsLazy<ToType> {
                                          lazyTypes = lazyTypes
                                      };
        }

        [Obsolete]
        public bool NotContains(Type type) {
            return !lazyTypes.Contains(type);
        }

        public bool NotContains<TX>() {
            return !lazyTypes.Contains(typeof(TX));
        }
    }
}