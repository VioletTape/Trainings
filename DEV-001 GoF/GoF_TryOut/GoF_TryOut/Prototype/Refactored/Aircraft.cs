using System.Collections.Generic;
using AutoMapper;

namespace GoF_TryOut.Prototype.Refactored {
    public class Aircraft {
        private IMappingExpression<Aircraft, Aircraft> mapping;

        public Aircraft() {
            mapping = Mapper.CreateMap<Aircraft,Aircraft>();
        }

        public string Manufactirer { get; set; }
        public string Model { get; set; }
        public PlaneType Type { get; set; }
        public int Payload { get; set; }
        public decimal Height { get; set; }
        public decimal Lenght { get; set; }
        public decimal WingsSpan { get; set; }
        public decimal TopSpeed { get; set; }
        public decimal AvrSpeed { get; set; }
        public List<Engine> Engines { get; set; }

        public Aircraft Clone() {
            return Mapper.Map<Aircraft>(this);
        }
    }

    public enum PlaneType {
        Military,
        Civil
    }

    public class Engine {
        private IMappingExpression<Engine, Engine> mapping;

        public Engine()
        {
            mapping = Mapper.CreateMap<Engine, Engine>();
        }

        public string Manufactirer { get; set; }
        public string Model { get; set; }
        public EngineType Type { get; set; }
        public int Power { get; set; }
        public int Endurance { get; set; }

        public Engine Clone()
        {
            return Mapper.Map<Engine>(this);
        }
    }

    public enum EngineType {
        SuperSonic,
        SuperJet,
        Propellers
    }
}