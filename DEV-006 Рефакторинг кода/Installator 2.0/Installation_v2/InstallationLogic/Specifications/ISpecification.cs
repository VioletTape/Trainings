namespace Installation_v2.InstallationLogic.Specifications {
    public interface ISpecification {
        bool IsSatisfied<T>(T item);
    }
}