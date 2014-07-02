using System.Collections.Generic;

namespace GoF_TryOut.Mediator.Refactored {
    public class Mediator {
        private readonly List<Plane> planes = new List<Plane>();
        private readonly FlightDispatcher dispatcher = new FlightDispatcher();

        public void Register(Plane plane) {
            planes.Add(plane);
            plane.SetMediator(this);
        }

        public void MoveToFirstEchelon(Plane plane) {
            var echelon = planes.FindAll(p => p.Echelon == Echelon.First);
            dispatcher.MoveToFirstEchelon(echelon, plane);
            foreach (var p in echelon) {
                p.Notify("new plane {0} in echelon", plane.Id);
            }
        }

        public void MoveToSecondEchelon(Plane plane) {
            var echelon = planes.FindAll(p => p.Echelon == Echelon.Second);
            dispatcher.MoveToSecondEchelon(echelon, plane);
            foreach (var p in echelon) {
                p.Notify("new plane {0} in echelon", plane.Id);
            }
        }

        public void MoveToThirdEchelon(Plane plane) {
            var echelon = planes.FindAll(p => p.Echelon == Echelon.Third);
            dispatcher.MoveToThirdEchelon(echelon, plane);
            foreach (var p in echelon) {
                p.Notify("new plane {0} in echelon", plane.Id);
            }
        }

        public void Landing(Plane plane, bool isEmergency) {
            var landing = planes.FindAll(p => p.IsLanding);
            var takeoff = planes.FindAll(p => p.IsTakeoff);

            if (isEmergency) {
                foreach (var p in landing) {
                    p.MoveToFirstEchelon();
                }
                foreach (var p in takeoff) {
                    p.RemainPosition();
                }
                return;
            }

            foreach (var p in landing) {
                p.Notify("landing {0} in queue", plane.Id);
            }

            dispatcher.Landing(plane);
        }

        public void Takeoff(Plane plane) {
            var takeoff = planes.FindAll(p => p.IsTakeoff);
            foreach (var p in takeoff) {
                p.Notify("takeoff {0} in queue", plane.Id);
            }
        }
    }
}