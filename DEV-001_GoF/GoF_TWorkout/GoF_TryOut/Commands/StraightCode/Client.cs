namespace GoF_TryOut.Commands.StraightCode {
    public class Client {
        public Client() {
            var devastatorRemoteController = new DevastatorRemoteController();
            var devastator1 = new Devastator(new Channel {Frequncy = "23S"});
            devastatorRemoteController.Add(devastator1);

            var devastator2 = new Devastator(new Channel {Frequncy = "88Q"});
            devastatorRemoteController.Add(devastator2);

            devastatorRemoteController.SetChannel(devastator1.Channel);
            devastatorRemoteController.MoveBackward();
            devastatorRemoteController.Boost();

            devastatorRemoteController.SetChannel(devastator2.Channel);
            devastatorRemoteController.MoveLeft();
            devastatorRemoteController.FlipUp();
        }
    }
}