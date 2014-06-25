namespace Commons {
    public interface IService {
        string Name { get; set; }

        void Do(object obj);
    }
}