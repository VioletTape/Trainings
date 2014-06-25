using System.Media;

namespace GoF_ShowCase.Adapter.ObjectAdapter {
    public class SoundPlayerAdapter : SoundPlayer, IAudioPlayer {
        public void Load(string file) {
            SoundLocation = file;
            Load();
        }
    }
}