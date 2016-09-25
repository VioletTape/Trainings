using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Infrastructure.Adapters.Base;
using SpecificationMain;
using StructureMap;
using VioletTape.Omnibus;

namespace Infrastructure {
    public class InfrastructureFacade : IInfrastructureFacade {
        private readonly UnitOfWork unitOfWork;

        public IUnitOfWork UnitOfWork {
            get { return unitOfWork; }
        }

public InfrastructureFacade() {
    unitOfWork = new UnitOfWork();
}

public InfrastructureFacade(IUnitOfWork unitOfWork) {
    this.unitOfWork = (UnitOfWork) unitOfWork;
}

        public List<T> Get<T>(Specification<T> specification) {
            var adapter = GetAdapter<T>();
            var list = adapter.Get(unitOfWork, specification);
            return list.FindAll(specification);
        }

        internal IReadAdapter<T> GetAdapter<T>() {
            var instance = ObjectFactory.Container
                .ForGenericType(typeof (IReadAdapter<>))
                .WithParameters(typeof (T))
                .GetInstanceAs<IReadAdapter<T>>();

            if (instance.IsNull()) {
                var type = typeof (T);
                throw new ArgumentOutOfRangeException("", type, string.Format("Type {0} not registered/founded", type.Name));
            }

            return instance;
        }

        public void Commit(IUnitOfWork unitOfWork) {
            var adapters = ObjectFactory.Container.GetAllInstances<IWriteAdapter>().ToList();
            adapters.Sort((x, y) => x.Sequence.CompareTo(y.Sequence));
            adapters.ForEach(i => i.Save((UnitOfWork) unitOfWork));
        }
    }
}