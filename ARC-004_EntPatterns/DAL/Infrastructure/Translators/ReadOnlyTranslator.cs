using Domain;
using SpecificationMain;

namespace Infrastructure.Translators {
    public abstract class ReadOnlyTranslator<TDomain, TBase>
        where TDomain : class
        where TBase : class {
        public virtual TDomain Reconstitute(TBase dataObject, IUnitOfWork unitOfWork, IsLazy<TDomain> isLazy) {
            if (ReferenceEquals(dataObject, null)) {
                return null;
            }

            var domainObject = unitOfWork.GetActive<TDomain>().Find(i => GetPredicate(i,dataObject));
            if (domainObject != null) {
                return domainObject;
            }

            domainObject = DoReconstitute(dataObject, isLazy, unitOfWork);
            ((UnitOfWork) unitOfWork).Register(domainObject);
            return domainObject;
        }

        protected abstract TDomain DoReconstitute(TBase dataObject, IsLazy<TDomain> isLazy, IUnitOfWork unitOfWork);

        protected abstract bool GetPredicate(TDomain domain, TBase data);
        }
}