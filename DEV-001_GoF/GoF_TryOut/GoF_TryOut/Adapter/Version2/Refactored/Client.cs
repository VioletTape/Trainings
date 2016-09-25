using System.Collections.Generic;

namespace GoF_TryOut.Adapter.Version2.Refactored {
    public class SuperHeroAdapter {
        public SuperHero GetHero(superhero superheroDto) {
            var hero = new SuperHero {
                                         Name = superheroDto.HeroName,
                                         RealName = superheroDto.HeroName,
                                         Description = superheroDto.Description
                                     };

            var superAbilityAdapter = new SuperAbilityAdapter();
            superheroDto.Abilities.ForEach(s => hero.SetAbility(superAbilityAdapter.GetSuperAbility(s)));

            hero.WeakPoint = superAbilityAdapter.GetSuperAbility(superheroDto.WeakPoint);

            return hero;
        }
    }

    public class SuperAbilityAdapter {
        public SuperAbility GetSuperAbility(string ability) {
            return new SuperAbility(ability);
        }
    }

    public class SuperHero {
        public string Name { get; set; }
        public string Description { get; set; }
        public SuperAbility WeakPoint { get; set; }
        public string RealName;
        public List<SuperAbility> Abilities { get; }


        public SuperHero() {
            Abilities = new List<SuperAbility>();
        }

        public void SetAbility(SuperAbility superAbility) {
            Abilities.Add(superAbility);
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