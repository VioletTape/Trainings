namespace Infrastructure.Adapters.Base {
    public interface IWriteAdapter {
        void Save(UnitOfWork unitOfWork);
        int Sequence { get; }
    }
}