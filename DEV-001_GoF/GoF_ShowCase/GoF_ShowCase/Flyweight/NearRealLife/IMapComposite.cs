namespace GoF_ShowCase.Flyweight.NearRealLife {
    public interface IMapComposite : IMapComponent {
        void AddComponent(IMapComponent component, int x, int y);
    }
}