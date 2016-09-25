namespace GoF_ShowCase.Adapter.ClassAdapter {
    internal class Example {
        private readonly IAudioPlayer player 
            = new SoundPlayerAdapter();

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