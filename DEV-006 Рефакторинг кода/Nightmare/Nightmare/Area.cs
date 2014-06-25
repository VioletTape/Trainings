namespace Nightmare {
    /// <summary>
    /// Класс содержит информацию об области где находится главный герой. 
    /// В зависимости от типа области накладываются штрафы или бонусы на героя 
    /// (так же зависят от способностей героя) 
    /// </summary>
    public class Area {
        public string Name;
        public AreaType AreaType;
        /// <summary>
        /// 
        /// </summary>
        public bool IsFightArea;
        /// <summary>
        /// зона торговли или нет
        /// </summary>
        public bool IsMerchArea;
        /// <summary>
        /// является ли это скрытой областью, которая открывается спец.средствами
        /// </summary>
        public bool IsSecretArea;
        /// <summary>
        /// количество опыта герою за открытие зоны 
        /// </summary>
        public int DiscoverXp;

        public void PlayerEnter(Character character) {
            
        }
    }
}