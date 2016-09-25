using System.Collections.Generic;

namespace Nightmare {
    /// <summary>
    /// Базовый класс для всех типов существ с которым будет сражаться главный герой
    /// Класс содержит все данные, которые учитываются при расчете защиты и атаки
    /// </summary>
    public class Beast {
        public int Flying = 0;
        public int Stomping = 0;
        public int Poison = 0;
        public int Life = 10;   
        public int Stamina = 10;
        public int Xp = 3;
        public int Level = 1;
        public int BaseAttack = 1;
        public int Defence = 0;
        public int Name;

        public int Stunned;

        /// <summary>
        /// There are might 
        /// </summary>
        /// <returns></returns>
        public List<Attack> Attack() {
            var result = new Attack {
                Defence = 0,
                Power = BaseAttack,
                Special = 0
            };

            var val = BaseAttack;

            if (Flying == 1) {
                val = val + (int) (Level*0.7m);
            }
            result.Special += val;

            if (Flying == 1) {
                val = (int) (Defence*1.2m);
            }
            result.Defence += val;


            if (Stomping > 0) {
                val = result.Power + Stomping;
            }
            result.Power = val;

            if (Stomping > 0) {
                val = result.Special + Stomping;
            }
            result.Special += val;

            // If beast with Poison ability he can attack twice
            return Poison == 0
                ? new List<Attack> {result}
                : new List<Attack> {result, result};
        }


        private bool IsStunned() {
            return Stunned > 0;
        }
    }

    public struct Attack {
        public int Power;
        public int Defence;
        public int Special;
    }
}