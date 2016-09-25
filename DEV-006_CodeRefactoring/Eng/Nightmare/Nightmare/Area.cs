namespace Nightmare {
    public class Area {
        public string Name;
        public AreaType AreaType;
        public bool IsFightArea;
   
        public bool IsMerchArea;
        /// <summary>
        /// Indicate is it secret area or not
        /// </summary>
        public bool IsSecretArea;
        /// <summary>
        /// XP that gets hero for discovering
        /// </summary>
        public int DiscoverXp;

        public void PlayerEnter(Character character) {
            
        }
    }
}