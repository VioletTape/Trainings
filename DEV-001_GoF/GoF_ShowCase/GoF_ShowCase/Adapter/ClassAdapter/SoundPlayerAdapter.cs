using System;
using System.Media;

namespace GoF_ShowCase.Adapter.ClassAdapter {
    public class SoundPlayerAdapter : IAudioPlayer {
        private readonly Lazy<SoundPlayer> lazyPlayer 
            = new Lazy<SoundPlayer>();

        public void Load(string file) {
            lazyPlayer.Value.SoundLocation = file;
            lazyPlayer.Value.Load();
        }

        public void Play() {
            lazyPlayer.Value.Play();
        }
    }
}