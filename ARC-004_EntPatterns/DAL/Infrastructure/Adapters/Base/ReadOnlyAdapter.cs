using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using Infrastructure.Context;
using Infrastructure.QueryBuilders;
using Infrastructure.Translators;
using SpecificationMain;
using StructureMap;

namespace Infrastructure.Adapters.Base {
    public abstract class ReadOnlyAdapter<TDomain, TData> : IReadAdapter<TDomain>
        where TDomain : class
        where TData : class, new() {
        protected Table<TData> Table;
private readonly ReadOnlyTranslator<TDomain, TData> translator;

protected ReadOnlyAdapter(ReadOnlyTranslator<TDomain, TData> translator) {
    this.translator = translator;
}

public virtual List<TDomain> Get(UnitOfWork unitOfWork, Specification<TDomain> specification) {
    var isLazy = specification.ExtractSupersetSpecification<IsLazy<TDomain>>() ?? new IsLazy<TDomain>();
    var list = (from dataObject in PrepareQuery(specification)
                select dataObject).ToList();

    var result = new List<TDomain>();
    list.ForEach(i => result.Add(translator.Reconstitute(i, unitOfWork, isLazy)));

    return result;
}

private IQueryable<TData> PrepareQuery(Specification<TDomain> specification) {
    var options = new DataLoadOptions();
    DoConfigureLoad(options);

    var context = new WarehouseDataContext(ConnectionHelper.CurrentConnection);
    context.LoadOptions = options;

    var preparedQuery = GetQueryBuilder().Optimize(GetBaseQuery(context), specification);
    return preparedQuery;
}

private IQueryBuilder<TDomain, TData> GetQueryBuilder() {
    var queryBuilders = ObjectFactory.Container
        .ForGenericType(typeof (IQueryBuilder<,>))
        .WithParameters(typeof (TDomain), typeof (TData))
        .GetInstanceAs<IQueryBuilder<TDomain, TData>>();

    return queryBuilders;
}

protected virtual IQueryable<TData> GetBaseQuery(DataContext dataContext) {
    var attemptsLeft = 5;
    while (attemptsLeft > 0) {
        try {
            return dataContext.GetTable<TData>();
        }
        catch (Exception) {
            attemptsLeft--;
        }
    }

    throw new InvalidOperationException(string.Format("Cant'get table from Context for {0}", typeof (TDomain).Name));
}

        protected virtual void DoConfigureLoad(DataLoadOptions options) {}
        }
}