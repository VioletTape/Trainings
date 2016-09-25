using System.Linq;

namespace GoF_TryOut.Adapter.Refactored {
    public abstract class Adapter<T> {
        private readonly Table<T> table;
        protected Adapter(Table<T>  table) {
            this.table = table;
        }

        internal IQueryable<T> CommonConditions(Specification<T> specification) {
            var query = table.AsQueryable();
            
            var top = specification.ExtractSupersetSpecification<TopSpecification<T>>();

            if (top != null) {
                query = query.Take(top.Top);
            }

            return query;
        }

        public abstract IQueryable<T> Convert(Specification<T> specification);
    }
}