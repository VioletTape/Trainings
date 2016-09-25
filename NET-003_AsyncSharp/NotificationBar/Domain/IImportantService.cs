namespace Domain {
    public interface IImportantService {
        void PretendItLastsFor(int seconds);
        T PretendItLastsFor<T>(int seconds);
    }
}