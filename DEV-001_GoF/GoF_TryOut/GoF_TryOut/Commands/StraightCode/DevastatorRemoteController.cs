using System;
using System.Collections.Generic;
using System.Linq;

namespace GoF_TryOut.Commands.StraightCode {
    public class DevastatorRemoteController {
        private readonly Dictionary<Channel, Devastator> devastators;

        public Channel CurrentChannel { get; private set; }

        public DevastatorRemoteController() {
            devastators = new Dictionary<Channel, Devastator>();
        }

        public void Add(Devastator devastator) {
            devastators.Add(devastator.Channel, devastator);
        }

        public List<Channel> GetChannels() {
            return devastators.Keys.ToList();
        }

        public void SetChannel(Channel channel) {
            if (devastators.ContainsKey(channel)) {
                CurrentChannel = channel;
            }
        }

        public void MoveLeft() {
            devastators[CurrentChannel].MoveLeft();
        }

        public void MoveRight() {
            devastators[CurrentChannel].MoveRight();
        }

        public void MoveForward() {
            devastators[CurrentChannel].MoveForward();
        }

        public void MoveBackward() {
            devastators[CurrentChannel].MoveBackward();
        }

        public void AttackChainsaw() {
            devastators[CurrentChannel].AttackChainsaw();
        }

        public void Boost() {
            devastators[CurrentChannel].Boost();
        }

        public void FlipUp() {
            devastators[CurrentChannel].FlipUp();
        }
    }
}