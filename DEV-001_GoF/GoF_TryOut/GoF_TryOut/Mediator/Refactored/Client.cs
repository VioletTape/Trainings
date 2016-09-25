using System;
using System.Collections.Generic;

namespace GoF_TryOut.Mediator.Refactored {
    public class Client {
        public Client() {
            var mediator = new Mediator();
            var m1 = new Messenger("m1");
            var m2 = new Messenger("m2");
            var m3 = new Messenger("m3");
            var m4 = new Messenger("m4");
            var m5 = new Messenger("m5");

            mediator.Subscribe("g1", m2);
            mediator.Subscribe("g1", m3);
            mediator.Subscribe("g1", m4);

            mediator.Subscribe("g2", m1);
            mediator.Subscribe("g2", m3);
            mediator.Subscribe("g2", m4);
            mediator.Subscribe("g2", m5);

            mediator.Send("g1", "hello");

            mediator.SendDirect("m4", "personal message");
        }
    }

    public class Mediator {
        readonly Dictionary<string, List<IReciever>> routes = new Dictionary<string, List<IReciever>>();
        readonly Dictionary<string, IReciever> recievers = new Dictionary<string, IReciever>();

        public void Subscribe(string group, IReciever reciever) {
            if (!routes.ContainsKey(group))
                routes[group] = new List<IReciever>();

            routes[group].Add(reciever);

            if (!recievers.ContainsKey(reciever.Name))
                recievers.Add(reciever.Name, reciever);
        }

        public void Send<T>(string group, T message) {
            routes[group].ForEach(i => i.Accept(message));
        }

        public void SendDirect<T>(string recieverName, T message) {
            recievers[recieverName].Accept(message);
        }
    }

    public class Messenger : IReciever {
        public Messenger(string name) {
            Name = name;
        }

        public void Accept<T>(T message) {
            Console.WriteLine(Name + " > " + message);
        }

        public string Name { get; set; }
    }

    public interface IReciever {
        void Accept<T>(T message);
        string Name { get; set; }
    }
}