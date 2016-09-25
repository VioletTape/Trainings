
namespace GoF_ShowCase.Adapter.ObjectAdapter {
    /*
     Но стоит помнить, что в этом случае усиливается связь между адаптируемым объектом и кодом приложения. И это самый большой минус данного варианта.
    
     */

    internal class Example {
        private readonly IAudioPlayer player = new SoundPlayerAdapter();

        public void NotifyUser(int messageCode) {
            var wavFile = string.Empty;

            /* Skipped */

            // play the audio file
            if (!string.IsNullOrEmpty(wavFile)) {
                player.Load(wavFile);
                player.Play();
            }
        }
    }
}