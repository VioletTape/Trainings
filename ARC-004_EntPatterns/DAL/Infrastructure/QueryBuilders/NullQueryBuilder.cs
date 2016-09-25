using System.Linq;
using Domain;
using Infrastructure.Context;
using SpecificationMain;

namespace Infrastructure.QueryBuilders {
public abstract class NullQueryBuilder<TDomain, TData> : IQueryBuilder<TDomain, TData> {
    public IQueryable<TData> Optimize(IQueryable<TData> query, Specification<TDomain> specification) {
        return query;
    }
}

public class WareQueryBuilder : NullQueryBuilder<Ware, ware> {}
public class InvoiceQueryBuilder : NullQueryBuilder<Invoice, invoice> {}
}