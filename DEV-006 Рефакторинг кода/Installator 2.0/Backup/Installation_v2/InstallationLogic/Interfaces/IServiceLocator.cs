namespace Installation_v2.InstallationLogic.Interfaces {
    public interface IServiceLocator {
        T Get<T>();
    }
}