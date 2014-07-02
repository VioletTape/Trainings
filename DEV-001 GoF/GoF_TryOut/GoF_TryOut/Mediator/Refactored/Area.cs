using System.Collections.Generic;
using GoF_TryOut.Mediator.Straight;

namespace GoF_TryOut.Mediator.Refactored {
    public class Area {
        public List<Plane> Planes = new List<Plane>();

        public Area(Mediator mediator) {
            Planes.Add(new Plane {Id = "RA-122"});
            Planes.Add(new Plane {Id = "RA-222"});
            Planes.Add(new Plane {Id = "RA-319"});
            Planes.Add(new Plane {Id = "ST-400"});
            Planes.Add(new Plane {Id = "ST-451"});
            Planes.Add(new Plane {Id = "ST-620"});
            Planes.Add(new Plane {Id = "ST-620"});
            Planes.Add(new Plane {Id = "RR-012"});
            Planes.Add(new Plane {Id = "RR-018"});
            Planes.Add(new Plane {Id = "RR-059"});


            foreach (var plane in Planes) {
                mediator.Register(plane);    
            }
        }
    }
}