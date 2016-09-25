namespace GoF_ShowCase.Composite.MapExample {
    public interface IMapComponent {
        IMapComponent Parent { get; set; }

        string Title { get; set; }

        void Draw(int x, int y);

        IMapComponent FindChild(string name);
    }
}