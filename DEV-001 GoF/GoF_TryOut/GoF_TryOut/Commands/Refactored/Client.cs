namespace GoF_TryOut.Commands.Refactored {
    public class Client {
        public Client() {
            var devastator1 = new Devastator(new Channel {Frequncy = "23S"});
            var devastator2 = new Devastator(new Channel {Frequncy = "55J"});

            var remote = new UniversalRemoteController();

            remote.RegisterCommand<Devastator>(CommandSet.CommandA, new AttachChainSawCommand());
            remote.RegisterCommand<Devastator>(CommandSet.CommandB, new BoostCommand());
            remote.RegisterCommand<Devastator>(CommandSet.CommandC, new FlipUpCommand());

            remote.Add(devastator1, devastator1.Channel);
            remote.Add(devastator2, devastator2.Channel);

            remote.SetChannel(devastator1.Channel);

            remote.MoveBackward();
            remote.CommandA();

            remote.SetChannel(devastator2.Channel);

            remote.MoveBackward();
            remote.MoveLeft();
            remote.CommandB();
        }
    }
}