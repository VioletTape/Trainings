using System.Collections.Generic;
using SpecificationMain;

namespace Infrastructure.Adapters.Base {
    public interface IReadAdapter<TDomain> {
        List<TDomain> Get(UnitOfWork unitOfWork, Specification<TDomain> specification);
    }
}