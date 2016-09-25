namespace GoF_ShowCase.Composite.MapExample {
    public interface IMapComposite : IMapComponent {
        void AddComponent(IMapComponent component);
    }
}