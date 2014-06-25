using System;
using System.Linq.Expressions;

namespace GoF_TryOut.Commands.Refactored {
    public class Devastator : IMovement {
        public Channel Channel { get; private set; }

        public Devastator(Channel channel) {
            Channel = channel;
        }

        public void MoveLeft() {
            Console.WriteLine(Channel.Frequncy + ":" + "Devastator turned left");
        }

        public void MoveRight() {
            Console.WriteLine(Channel.Frequncy + ":" + "Devastator turned rigth");
        }

        public void MoveForward() {
            Console.WriteLine(Channel.Frequncy + ":" + "Devastator moved forward");
        }

        public void MoveBackward() {
            Console.WriteLine(Channel.Frequncy + ":" + "Devastator moved backward");
        }

        public void AttackChainsaw() {
            Console.WriteLine(Channel.Frequncy + ":" + "Devastator used chainsaw");
        }

        public void Boost() {
            Console.WriteLine(Channel.Frequncy + ":" + "Devastator used boost");
        }

        public void FlipUp() {
            Console.WriteLine(Channel.Frequncy + ":" + "Devastator flipped up");
        }
    }

    public class AttachChainSawCommand : Command<Devastator> {
        public AttachChainSawCommand() : base(d => d.AttackChainsaw()) {}
    }

     public class BoostCommand : Command<Devastator> {
        public BoostCommand() : base(d => d.Boost()) {}
    }

    public class FlipUpCommand : Command<Devastator> {
        public FlipUpCommand() : base(d => d.FlipUp()) {}
    }

//    public class BoostCommand : ICommand {
//        public void Execute(object item) {
//            var methodInfo = typeof (Devastator).GetMethod("Boost");
//            methodInfo.Invoke(item, new object[]{});
//        }
//    }
//
//    public class FlipUpCommand : ICommand {
//        public void Execute(object item) {
//            var methodInfo = typeof (Devastator).GetMethod("FlipUp");
//            methodInfo.Invoke(item, new object[]{});
//        }
//    }
}