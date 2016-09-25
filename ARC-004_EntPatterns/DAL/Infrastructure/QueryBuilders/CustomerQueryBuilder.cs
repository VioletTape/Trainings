using System.Linq;
using Domain;
using Domain.Specifications;
using Infrastructure.Context;
using SpecificationMain;
using VioletTape.Omnibus;

namespace Infrastructure.QueryBuilders {
public class CustomerQueryBuilder : IQueryBuilder<Customer, customer> {
    public IQueryable<customer> Optimize(IQueryable<customer> query, Specification<Customer> specification) {

        var belongsToBase = specification.ExtractSupersetSpecification<ActiveCustomer>();
        if (belongsToBase.IsNotNull()) {
            query = query.Where(i => i.invoices.Any());
        }

        var titleStartsWith  = specification.ExtractSupersetSpecification<CustomerTitleStartsWith>();
        if (titleStartsWith.IsNotNull()) {
            query = query.Where(i => i.Title.StartsWith(titleStartsWith.StartPattern));
        }

        return query;
    }
}
}