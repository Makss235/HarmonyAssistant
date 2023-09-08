using System.Speech.Synthesis;

namespace HarmonyAssistant.Core.TTS
{
    public class TTS
    {
        private SpeechSynthesizer speechSynthesizer;

        #region Singleton

        private static TTS instance;
        public static TTS GetInstance()
        {
            if (instance == null)
                instance = new TTS();
            return instance;
        }

        #endregion

        private TTS()
        {
            speechSynthesizer = new SpeechSynthesizer();

            speechSynthesizer.Volume = 100;
            speechSynthesizer.Rate = 2;

            foreach (InstalledVoice installedVoice in speechSynthesizer.GetInstalledVoices())
            {
                if (installedVoice.VoiceInfo.Id == "Aleksandr-hq")
                    speechSynthesizer.SelectVoice(installedVoice.VoiceInfo.Name);
            }
        }

        public void Speak(string text)
        {
            speechSynthesizer.SpeakAsync(text);
        }
    }
}
