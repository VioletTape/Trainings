namespace GoF_TryOut.Prototype.Straight {
    public class Aircraft {
        public string Manufactirer { get; set; }
        public string Model { get; set; }
        public PlaneType Type { get; set; }
        public int Weight { get; set; }
        public decimal Height { get; set; }
        public decimal Lenght { get; set; }
        public decimal WingsLenght { get; set; }
        public decimal TopSpeed { get; set; }
        public decimal AvrSpeed { get; set; }
        public Engine Engines { get; set; }
    }

    public enum PlaneType {
        Military,
        Civil
    }

    public class Engine {
        public string Manufactirer { get; set; }
        public string Model { get; set; }
        public EngineType Type { get; set; }
        public int Power { get; set; }
        public int Endurance { get; set; }
    }

    public enum EngineType {
        SuperSonic,
        SuperJet,
    }
}