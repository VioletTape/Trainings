using System;
using System.Data.Linq;
using System.Linq;
using Infrastructure.Context;
using Infrastructure.Translators;

namespace Infrastructure.Adapters.Base {
    public abstract class WriteAdapter<TDomain, TData> : ReadOnlyAdapter<TDomain, TData>, IWriteAdapter
        where TDomain : class
        where TData : class, new() {
        private readonly Translator<TDomain, TData> translator;

        protected DataContext context;

        public virtual int Sequence {
            get { return 100; }
        }

        protected WriteAdapter(Translator<TDomain, TData> translator) : base(translator) {
            this.translator = translator;
        }

        public void Save(UnitOfWork unitOfWork) {
            context = new WarehouseDataContext(ConnectionHelper.CurrentConnection);

            Table = context.GetTable<TData>();

            unitOfWork.ForEachInserted<TDomain>(
                domainObject => {
                    var dataObject = new TData();
                    translator.Persist(domainObject, dataObject, unitOfWork);
//                    translator.PersistCreatedAuditableFields(dataObject);
                    Table.InsertOnSubmit(dataObject);
                    context.SubmitChanges();
//                    unitOfWork.UpdateIdentity(domainObject, dataObject.id);
                });

            unitOfWork.ForEachUpdated<TDomain>(
                (domainObject) => {
                    var dataObject = GetSingle(domainObject);
                    if (dataObject != null) {
                        translator.Persist(domainObject, dataObject, unitOfWork);
                    }
                });

            context.SubmitChanges();

            unitOfWork.ForEachDeleted<TDomain>(
                (domainObject) => {
                    var dataObject = GetSingle(domainObject);
                    if (dataObject != null) {
                        translator.AssertCanBeDeleted(dataObject);
                        DeleteDataObject(dataObject);
                    }
                });


            context.SubmitChanges();

            AfterCommit(unitOfWork);
        }

        protected virtual void DeleteDataObject(TData dataObject) {
            Table.DeleteOnSubmit(dataObject);
        }

        protected virtual void AfterCommit(UnitOfWork unitOfWork) {}

        public TData GetSingle(TDomain domainObject) {
            return context.GetTable<TData>().Single(GetIdPredicate(domainObject));
        }

        protected abstract Func<TData, bool> GetIdPredicate(TDomain domainObject);
        }
}