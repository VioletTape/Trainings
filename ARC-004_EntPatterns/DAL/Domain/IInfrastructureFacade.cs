using System.Collections.Generic;
using SpecificationMain;

namespace Domain {
public interface IInfrastructureFacade {
    IUnitOfWork UnitOfWork { get; }
    List<T> Get<T>(Specification<T> specification);
    void Commit(IUnitOfWork unitOfWork);
}
}