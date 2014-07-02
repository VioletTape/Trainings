using System.Collections.Generic;
using System.Linq;

namespace GoF_TryOut.Mediator.Refactored {
    public class Mediator {
        private readonly List<Plane> planes = new List<Plane>();

        public void Register(Plane plane) {
            planes.Add(plane);
        }

        public void MoveToFirstEchelon(Plane plane) {
            var firstEchelon = planes.FindAll(p => p.Echelon == Echelon.First);
            if (firstEchelon.Count <= 5) {
                foreach (var p in firstEchelon) {
                    p.Notify("new plane in echelon");
                }
                plane.Echelon = Echelon.First;
            }
            else {
                plane.RemainPosition();
            }
        }
    }

    public class FlightDispatcher {
        public void MoveToFirstEchelon() {
            
        }

        public void MoveToSecondEchelon() {
            
        }
        
    }

    public class Plane {
        private Mediator mediator;

        public Echelon Echelon;

        public bool IsLanding;
        public bool IsTakeoff;
        public string Id { get; set; }

        public void Notify(string message) {}


        public void MoveToFirstEchelon() {
            if (Echelon == Echelon.First) {
                return;
            }

            mediator.MoveToFirstEchelon(this);
        }

        public void MoveToSecondEchelon() {
            if (Echelon == Echelon.Second) {
                return;
            }

            var firstEchelon = planes.FindAll(p => p.Echelon == Echelon.Second);
            if (firstEchelon.Count <= 5) {
                Echelon = Echelon.Second;
                foreach (var plane in firstEchelon) {
                    plane.Notify("new plane in echelon");
                }
            }
        }

        public void MoveToThirdEchelon() {
            if (Echelon == Echelon.Third) {
                return;
            }

            var firstEchelon = planes.FindAll(p => p.Echelon == Echelon.Third);
            if (firstEchelon.Count <= 5) {
                Echelon = Echelon.Third;
                foreach (var plane in firstEchelon) {
                    plane.Notify("new plane in echelon");
                }
            }
        }

        public void Landing(bool isEmergency = false) {
            var landing = planes.FindAll(p => p.IsLanding);
            var takeoff = planes.FindAll(p => p.IsTakeoff);

            if (isEmergency) {
                foreach (var plane in landing) {
                    plane.MoveToThirdEchelon();
                }
                foreach (var plane in takeoff) {
                    plane.RemainPosition();
                }
                return;
            }

            foreach (var plane in landing) {
                plane.Notify("landing in queue");
            }
        }

        public void TakeOff() {
            var takeoff = planes.FindAll(p => p.IsTakeoff);
            foreach (var plane in takeoff) {
                plane.Notify("takeoff in queue");
            }
        }

        public void RemainPosition() {}

        public void FindNearbyPlanes(Area area) {
            planes = area.Planes.Where(p => p.Id.Contains("0")).ToList();
        }
    }