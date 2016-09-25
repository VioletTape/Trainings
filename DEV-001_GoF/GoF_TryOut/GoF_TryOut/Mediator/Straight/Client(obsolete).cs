using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GoF_TryOut.Mediator.Straight {
   /* public class Client {
        public Client() {
            


        }
    }

    public class Member {
        private static readonly Dictionary<string, Member> dictionary = new Dictionary<string, Member>();

        public string Name { get; set; }

        private Member(string name) {
            Name = name;
        }

        public static Member Create(string name) {
            var member = new Member(name);
            dictionary[member.Name] = member;

            return member;
        }

        public void Send(Member to, string message) {
            dictionary[to.Name].Notify(message);
        }

        private void Notify(string message) {
            Console.WriteLine(message);
        }
    }

    public class MemberService {
        private readonly List<MemberX> members = new List<MemberX>();

        public void Add(MemberX member) {
            members.Add(member);
        }

        public void Send(MemberX member, string message) {
            var memberX = members.SingleOrDefault(m => m.Name == member.Name);
            if (memberX != null) {
                memberX.Notify(message);
            }

        }
    }

    public class MemberX {
        public string Name { get; set; }

        public void Notify(string message) {
            Console.WriteLine(message);
        }
    }*/
}