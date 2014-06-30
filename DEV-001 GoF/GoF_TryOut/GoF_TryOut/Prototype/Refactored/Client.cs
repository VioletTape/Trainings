using System.Collections.Generic;

namespace GoF_TryOut.Prototype.Refactored {
    public class Client {
        public Client() {
            var engine = new Engine {
                Manufactirer = "Rolls-Royce",
                Model = "AE 2100",
                Type = EngineType.Propellers,
                Power = 4591,
                Endurance = 100
            };


            var saab2000 = new Aircraft {
                Manufactirer = "Saab",
                Model = "2000",
                Type = PlaneType.Civil,
                Payload = 5900,
                Height = 7.73m,
                Lenght = 27.28m,
                WingsSpan = 24.76m,
                TopSpeed = 730,
                AvrSpeed = 665, 
                Engines = new List<Engine> {
                    engine.Clone(), engine.Clone()
                },
            };

            var saab200Fi = saab2000.Clone();
            saab200Fi.Payload = 6500;
        }
    }
}