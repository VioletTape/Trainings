namespace Nightmare {
    public class LifePotion : Item {
        public void Use(Character character) {
            new ExperienceService().FillLife(character);
        }
    }
}