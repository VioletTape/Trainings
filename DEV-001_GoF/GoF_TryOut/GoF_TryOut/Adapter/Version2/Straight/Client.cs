using System.Collections.Generic;

namespace GoF_TryOut.Adapter.Version2.Straight {
    public class SuperHero {
        private readonly superhero superhero;
        private string name;

        public string Name {
            get { return superhero.HeroName; }
            set { superhero.HeroName = value; }
        }

        public string Description {
            get { return superhero.Description; }
            set { superhero.Description = value; }
        }

        public SuperAbility WeakPoint { get; set; }
        

        public string HeroicName;

        public List<SuperAbility> Abilities { get; }


        public SuperHero(superhero superhero) {
            this.superhero = superhero;
            Abilities = new List<SuperAbility>();
            superhero.Abilities.ForEach(i => Abilities.Add(new SuperAbility(i)));
            HeroicName = superhero.HeroName;
            WeakPoint = new SuperAbility(superhero.WeakPoint);
        }
    }

    public class SuperAbility {
        public AbilityType AbilityType;

        public SuperAbility(string s) {
            // reconstitute ability type
        }
    }

    public enum AbilityType {
        Ranged,
        Close
    }

    public class superhero {
        public string HeroName;
        public string RealName;
        public List<string> Abilities;
        public string Description;
        public List<superhero> Enemies;
        public List<superhero> Aliases;
        public string WeakPoint;
    }
}