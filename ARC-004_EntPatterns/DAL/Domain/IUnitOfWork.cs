using System.Collections.Generic;

namespace Domain {
    public interface IUnitOfWork {
        void Save(object item);
        void Delete(object item);
        void Commit();
        void Rollback();
        void Clear();
        List<T> GetActive<T>();
    }
}