namespace GoF_TryOut.Mediator.Straight {
    public class Client {
        public Client() {
            var area = new Area();

            area.Planes[3].FindNearbyPlanes(area);
            area.Planes[3].MoveToSecondEchelon();

            area.Planes[1].FindNearbyPlanes(area);
            area.Planes[1].TakeOff();

            area.Planes[0].FindNearbyPlanes(area);
            area.Planes[0].TakeOff();

            area.Planes[5].FindNearbyPlanes(area);
            area.Planes[5].Landing();

        }
    }

    public enum Echelon {
        First,
        Second,
        Third
    }
}