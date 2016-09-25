using System;
using System.Collections.Generic;
using System.Linq;

namespace GoF_TryOut.Commands.Refactored {
    public class UniversalRemoteController {
        private readonly Dictionary<Channel, IMovement> items;
        private readonly Dictionary<Type, Dictionary<CommandSet, ICommand>> commands;

        public Channel CurrentChannel { get; private set; }

        public UniversalRemoteController() {
            items = new Dictionary<Channel, IMovement>();
            commands = new Dictionary<Type, Dictionary<CommandSet, ICommand>>();
        }

        public void Add<T>(T item, Channel channel) where T : IMovement {
            items.Add(channel, item);
        }

        public void RegisterCommand<T>(CommandSet commandSet, ICommand command) where T : IMovement {
            if (!commands.ContainsKey(typeof(T))) {
                commands[typeof(T)] = new Dictionary<CommandSet, ICommand>();
            }

            commands[typeof(T)].Add(commandSet, command);
        }

        public List<Channel> GetChannels() {
            return items.Keys.ToList();
        }

        public void SetChannel(Channel channel) {
            if (items.ContainsKey(channel)) {
                CurrentChannel = channel;
            }
        }

        public void MoveLeft() {
            items[CurrentChannel].MoveLeft();
        }

        public void MoveRight() {
            items[CurrentChannel].MoveRight();
        }

        public void MoveForward() {
            items[CurrentChannel].MoveForward();
        }

        public void MoveBackward() {
            items[CurrentChannel].MoveBackward();
        }

        public void CommandA() {
            var type = items[CurrentChannel].GetType();
            commands[type][CommandSet.CommandA].Execute(items[CurrentChannel]);
        }

        public void CommandB() {
            var type = items[CurrentChannel].GetType();
            commands[type][CommandSet.CommandB].Execute(items[CurrentChannel]);
        }

        public void CommandC() {
            var type = items[CurrentChannel].GetType();
            commands[type][CommandSet.CommandC].Execute(items[CurrentChannel]);
        }
    }

    public enum CommandSet {
        CommandA,
        CommandB,
        CommandC
    }
}