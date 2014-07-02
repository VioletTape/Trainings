using System.Collections.Generic;

namespace GoF_TryOut.Mediator.Refactored {
    public class FlightDispatcher {
        public void MoveToFirstEchelon(List<Plane> planes, Plane plane) {
            if (planes.Count <= 5) {
                plane.Echelon = Echelon.First;
            }
            else {
                plane.RemainPosition();
            }
        }

        public void MoveToSecondEchelon(List<Plane> planes, Plane plane) {
            if (planes.Count <= 5) {
                plane.Echelon = Echelon.Second;
            }
            else {
                plane.RemainPosition();
            }
        }

        public void MoveToThirdEchelon(List<Plane> planes, Plane plane) {
            plane.Echelon = Echelon.Third;
        }

        public void Landing(Plane plane) {
            
        }

        public void Takeoff(Plane plane) {
            
        }
    }
}