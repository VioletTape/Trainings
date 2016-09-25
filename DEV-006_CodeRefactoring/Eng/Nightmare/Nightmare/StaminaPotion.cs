namespace Nightmare {
    public class StaminaPotion : Item {
        public void Use(Character character) {
            new ExperienceService().FillStamina(character);
        }
    }
}