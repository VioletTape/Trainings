using System;
using System.Collections.Generic;

namespace GoF_TryOut.Mediator.Straight {
    public class Client {
        public Client() {
            var m1 = new Messenger("m1");
            var m2 = new Messenger("m2");
            var m3 = new Messenger("m3");
            var m4 = new Messenger("m4");
            var m5 = new Messenger("m5");

            m1.Subscribe("m2", m2);
            m1.Subscribe("m3", m3);
            m1.Subscribe("m4", m4);

            m2.Subscribe("m1", m1);
            m2.Subscribe("m3", m3);
            m2.Subscribe("m4", m4);
            m2.Subscribe("m5", m5);

            m1.Send("hello");

            m1.Send("m4", "personal message");
        }
    }

    public class Messenger : ISender, IReciever {
        private readonly string name;
        private Dictionary<string, IReciever> recievers = new Dictionary<string, IReciever>();

        public Messenger(string name) {
            this.name = name;
        }

        public void Subscribe(string name, IReciever messenger) {
            recievers.Add(name, messenger);
        }

        public void Send<T>(T message) {
            foreach (var reciever in recievers.Values) {
                reciever.Accept(message);
            }
        }

        public void Send<T>(string name, T message) {
            recievers[name].Accept(message);
        }


        public void Accept<T>(T message) {
            Console.WriteLine(name + " > " + message.ToString());
        }
    }

    public interface ISender {
        void Send<T>(T message);
        void Send<T>(string name, T message);
    }

    public interface IReciever {
        void Accept<T>(T message);
    }
}