using System;

namespace GoF_TryOut.Commands.StraightCode {
    public class Tank : IMovement {
        public Channel Channel { get; private set; }

        public Tank(Channel channel) {
            Channel = channel;
        }

        public void MoveLeft() {
            Console.WriteLine(Channel.Frequncy + ":" + "Tank turned left");
        }

        public void MoveRight() {
            Console.WriteLine(Channel.Frequncy + ":" + "Tank turned rigth");
        }

        public void MoveForward() {
            Console.WriteLine(Channel.Frequncy + ":" + "Tank moved forward");
        }

        public void MoveBackward() {
            Console.WriteLine(Channel.Frequncy + ":" + "Tank moved backward");
        }

        public void ShootMainWeapon() {
            Console.WriteLine(Channel.Frequncy + ":" + "Tank used main weapon");
        }

        public void ShootSecondaryWeapon() {
            Console.WriteLine(Channel.Frequncy + ":" + "Tank used secondary weapon");
        }

        public void AirDefenceManeuver() {
            Console.WriteLine(Channel.Frequncy + ":" + "Tank performed air defence maneuver");
        }
    }
}