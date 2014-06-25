using System.Collections.Generic;
using System.Linq;

namespace GoF_TryOut.Commands.Refactored {
    public class TankRemoteController {
        private readonly Dictionary<Channel, Tank> tanks;

        public Channel CurrentChannel { get; private set; }

        public TankRemoteController() {
            tanks = new Dictionary<Channel, Tank>();
        }

        public void Add(Tank devastator, Channel channel) {
            tanks.Add(channel, devastator);
        }

        public List<Channel> GetChannels() {
            return tanks.Keys.ToList();
        }

        public void SetChannel(Channel channel) {
            if (tanks.ContainsKey(channel)) {
                CurrentChannel = channel;
            }
        }

        public void MoveLeft() {
            tanks[CurrentChannel].MoveLeft();
        }

        public void MoveRight() {
            tanks[CurrentChannel].MoveRight();
        }

        public void MoveForward() {
            tanks[CurrentChannel].MoveForward();
        }

        public void MoveBackward() {
            tanks[CurrentChannel].MoveBackward();
        }

        public void ShootMainWeapon() {
            tanks[CurrentChannel].ShootMainWeapon();
        }

        public void ShootSecondaryWeapon() {
            tanks[CurrentChannel].ShootSecondaryWeapon();
        }

        public void AirDefenceManeuver() {
            tanks[CurrentChannel].AirDefenceManeuver();
        }
    }
}