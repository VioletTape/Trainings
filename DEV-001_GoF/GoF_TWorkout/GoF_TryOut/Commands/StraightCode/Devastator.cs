using System;

namespace GoF_TryOut.Commands.StraightCode {
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
}