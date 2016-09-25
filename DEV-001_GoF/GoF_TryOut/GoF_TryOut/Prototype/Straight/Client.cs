using System.Collections.Generic;

namespace GoF_TryOut.Prototype.Straight {
    public class Client {
        public Client() {



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
            };

            var engine1 = new Engine() {
                Manufactirer = "Rolls-Royce",
                Model = "AE 2100",
                Type = EngineType.Propellers,
                Power = 4591,
                Endurance = 100
            };

            var engine2 = new Engine()
            {
                Manufactirer = "Rolls-Royce",
                Model = "AE 2100",
                Type = EngineType.Propellers,
                Power = 4591,
                Endurance = 100
            };


            saab2000.Engines = new List<Engine> {
                engine1, engine2
            };

            var saab2000Fi = new Aircraft
            {
                Manufactirer = "Saab",
                Model = "2000 FI",
                Type = PlaneType.Civil,
                Payload = 6500,
                Height = 7.73m,
                Lenght = 27.28m,
                WingsSpan = 24.76m,
                TopSpeed = 730,
                AvrSpeed = 665,
            };

            var engine11 = new Engine()
            {
                Manufactirer = "Rolls-Royce",
                Model = "AE 2100",
                Type = EngineType.Propellers,
                Power = 4591,
                Endurance = 100
            };

            var engine12 = new Engine()
            {
                Manufactirer = "Rolls-Royce",
                Model = "AE 2100",
                Type = EngineType.Propellers,
                Power = 4591,
                Endurance = 100
            };

            saab2000Fi.Engines = new List<Engine> {
                engine11, engine12
            };

        }
    }
}