using System.Linq;
using SpecificationMain;

namespace Infrastructure.QueryBuilders {
public interface IQueryBuilder<TDomain, TData> {
    IQueryable<TData> Optimize(IQueryable<TData> query, Specification<TDomain> specification);
}
}