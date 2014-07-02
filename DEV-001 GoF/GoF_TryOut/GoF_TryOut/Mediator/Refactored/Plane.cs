namespace GoF_TryOut.Mediator.Refactored {
    public class Plane {
        private Mediator mediator;

        public Echelon Echelon;

        public bool IsLanding;
        public bool IsTakeoff;
        public string Id { get; set; }

        public void Notify(string message, params object[] obj) {}


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

            mediator.MoveToSecondEchelon(this);
        }

        public void MoveToThirdEchelon() {
            if (Echelon == Echelon.Third) {
                return;
            }

            mediator.MoveToThirdEchelon(this);
        }

        public void Landing(bool isEmergency = false) {
            mediator.Landing(this, isEmergency);
            IsLanding = true;
        }

        public void TakeOff() {
            mediator.Takeoff(this);
        }

        public void RemainPosition() {}

        public void SetMediator(Mediator mediator) {
            this.mediator = mediator;
        }
    }
}