namespace GoF_TryOut.Mediator.Refactored {
    public class Client {
        public Client() {
            var mediator = new Mediator();
            var area = new Area(mediator);

            area.Planes[3].MoveToSecondEchelon();
            area.Planes[1].TakeOff();
            area.Planes[0].TakeOff();
            area.Planes[5].Landing();
        }
    }

    public enum Echelon {
        First,
        Second,
        Third
    }
}