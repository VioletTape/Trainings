namespace Nightmare {
    /// <summary>
    /// Существо Пчела, летает
    /// </summary>
    public class Bee : Flying {
        /// <summary>
        /// Базовые показатели атаки и защиты
        /// </summary>
        public Bee() {
            BaseAttack = 1;
            Defence = 5;
        }

        /// <summary>
        /// Значение обычной атаки
        /// </summary>
        /// <returns></returns>
        public override int OrdinalAttack() {
            return 0;
        }

        /// <summary>
        /// Значение атаки с воздуха
        /// </summary>
        /// <returns></returns>
        public override int AirAttack() {
            return BaseAttack;
        }

        public override int SpecialAttack() {
            return 0;
        }

        public override int StunAttack() {
            return 0;
        }

        public override int BonusAttack() {
            return 0;
        }

        public override int OrdinalDefence() {
            return Defence;
        }

        public override int SpecialDefence() {
            return 0;
        }
    }
}