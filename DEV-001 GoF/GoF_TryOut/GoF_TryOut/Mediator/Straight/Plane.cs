using System.Collections.Generic;
using System.Linq;

namespace GoF_TryOut.Mediator.Straight {
    public class Plane {
        private List<Plane> planes;

        public Echelon Echelon;

        public bool IsLanding;
        public bool IsTakeoff;
        public string Id { get; set; }

        public void MoveToFirstEchelon() {
            if (Echelon == Echelon.First) {
                return;
            }

            var firstEchelon = planes.FindAll(p => p.Echelon == Echelon.First);
            if (firstEchelon.Count <= 5) {
                Echelon = Echelon.First;
                foreach (var plane in firstEchelon) {
                    plane.Notify("new plane {0} in echelon", Id);
                }
            }
        }

        private void Notify(string message, params object[] obj) {}

        public void MoveToSecondEchelon() {
            if (Echelon == Echelon.Second) {
                return;
            }

            var firstEchelon = planes.FindAll(p => p.Echelon == Echelon.Second);
            if (firstEchelon.Count <= 5) {
                Echelon = Echelon.Second;
                foreach (var plane in firstEchelon) {
                    plane.Notify("new plane {0} in echelon", Id);
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
                    plane.Notify("new plane {0} in echelon", Id);
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
                plane.Notify("landing {0} in queue", Id);
            }
        }

        public void TakeOff() {
            var takeoff = planes.FindAll(p => p.IsTakeoff);
            foreach (var plane in takeoff) {
                plane.Notify("takeoff {0} in queue", Id);
            }
        }

        private void RemainPosition() {}

        public void FindNearbyPlanes(Area area) {
            planes = area.Planes.Where(p => p.Id.Contains("0")).ToList();
        }
    }
}