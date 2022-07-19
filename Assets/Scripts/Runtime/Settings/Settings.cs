using UnityEngine;

namespace Scripts.Runtime.Settings
{
    public class Settings
    {
        public float MainVolume { get; set; }
        public float MusicVolume { get; set; }
        public float SfxVolume { get; set; }
        public float VoiceVolume { get; set; }
        public int Quality { get; set; }
        public bool Fullscreen { get; set; }
        public float ResolutionWidth { get; set; }
        public float ResolutionHeight { get; set; }
        public float ResolutionRefresh { get; set; }

        public static Settings Load()
        {
            return new Settings()
            {
                MainVolume = PlayerPrefs.GetFloat("MainVolume", 1f),
                MusicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f),
                SfxVolume = PlayerPrefs.GetFloat("SfxVolume", 1f),
                VoiceVolume = PlayerPrefs.GetFloat("VoiceVolume", 1f),
                Quality = PlayerPrefs.GetInt("Quality", QualitySettings.GetQualityLevel()),
                Fullscreen = PlayerPrefs.GetInt("Fullscreen", Screen.fullScreen == true ? 1 : 0) == 1,
                ResolutionWidth = PlayerPrefs.GetFloat("ResolutionWidth", Screen.currentResolution.width),
                ResolutionHeight = PlayerPrefs.GetFloat("ResolutionHeight", Screen.currentResolution.height),
                ResolutionRefresh = PlayerPrefs.GetFloat("ResolutionRefresh", Screen.currentResolution.refreshRate)
            };
        }

        public void Save()
        {
            PlayerPrefs.SetFloat("MainVolume", MainVolume);
            PlayerPrefs.SetFloat("MusicVolume", MusicVolume);
            PlayerPrefs.SetFloat("SfxVolume", SfxVolume);
            PlayerPrefs.SetFloat("VoiceVolume", VoiceVolume);
            PlayerPrefs.SetInt("Quality", Quality);
            PlayerPrefs.SetInt("Fullscreen", Fullscreen ? 1 : 0);
            PlayerPrefs.SetFloat("ResolutionWidth", ResolutionWidth);
            PlayerPrefs.SetFloat("ResolutionHeight", ResolutionHeight);
            PlayerPrefs.SetFloat("ResolutionRefresh", ResolutionRefresh);
            PlayerPrefs.Save();
        }
    }
}