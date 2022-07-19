using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Scripts.Runtime.Controller.Settings
{
    public class SettingsController : MonoBehaviour
    {
        [field: SerializeField] private AudioMixer AudioMixer { get; set; }
        [field: SerializeField] private TMP_Dropdown QualityDropdown { get; set; }
        [field: SerializeField] private TMP_Dropdown ResolutionDropdown { get; set; }
        [field: SerializeField] private Toggle FullScreenToggle { get; set; }
        [field: SerializeField] private Slider MainVolumeSlider { get; set; }
        [field: SerializeField] private Slider MusicVolumeSlider { get; set; }
        [field: SerializeField] private Slider SfxVolumeSlider { get; set; }
        [field: SerializeField] private Slider VoiceVolumeSlider { get; set; }
        private Resolution[] Resolutions { get; set; }
        private Runtime.Settings.Settings Settings { get; set; }

        public void OnEnable()
        {
            Settings = Runtime.Settings.Settings.Load();
            LoadFullscreen();
            LoadQuality();
            LoadResolutionValue();
            LoadMainVolume();
            LoadMusicVolume();
            LoadSfxVolume();
            LoadVoiceVolume();
        }

        public void OnDisable()
        {
            Settings.Save();
        }

        public void LoadMainVolume()
        {
            AudioMixer.SetFloat("MainVolume", Mathf.Log10(Settings.MainVolume) * 20f);
            MainVolumeSlider.value = Mathf.Pow(10f, Settings.MainVolume / 20f);
        }

        public void SetMainVolume(float volume)
        {
            AudioMixer.SetFloat("MainVolume", Mathf.Log10(volume) * 20f);
            Settings.MainVolume = volume;
        }

        public void LoadMusicVolume()
        {
            AudioMixer.SetFloat("MusicVolume", Mathf.Log10(Settings.MusicVolume) * 20f);
            MusicVolumeSlider.value = Mathf.Pow(10f, Settings.MusicVolume / 20f);
        }

        public void SetMusicVolume(float volume)
        {
            AudioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20f);
            Settings.MusicVolume = volume;
        }

        public void LoadSfxVolume()
        {
            AudioMixer.SetFloat("SfxVolume", Mathf.Log10(Settings.SfxVolume) * 20f);
            SfxVolumeSlider.value = Mathf.Pow(10f, Settings.SfxVolume / 20f);
        }

        public void SetSfxVolume(float volume)
        {
            AudioMixer.SetFloat("SfxVolume", Mathf.Log10(volume) * 20f);
            Settings.SfxVolume = volume;
        }

        public void LoadVoiceVolume()
        {
            AudioMixer.SetFloat("VoiceVolume", Mathf.Log10(Settings.VoiceVolume) * 20f);
            VoiceVolumeSlider.value = Mathf.Pow(10f, Settings.VoiceVolume / 20f);
        }

        public void SetVoiceVolume(float volume)
        {
            AudioMixer.SetFloat("VoiceVolume", Mathf.Log10(volume) * 20f);
            Settings.VoiceVolume = volume;
        }

        private void LoadQuality()
        {
            QualityDropdown.ClearOptions();
            QualityDropdown.AddOptions(QualitySettings.names.ToList());
            QualityDropdown.value = Settings.Quality;
            QualityDropdown.RefreshShownValue();
        }

        public void SetQuality(int quality)
        {
            QualitySettings.SetQualityLevel(quality);
            Settings.Quality = quality;
        }

        private void LoadResolutionValue()
        {
            int currentIndex = 0;
            List<string> options = new List<string>();
            for (int i = 0; i < Screen.resolutions.Length; i++)
            {
                if (Math.Abs(Screen.resolutions[i].width - Settings.ResolutionWidth) < 1f && Math.Abs(Screen.resolutions[i].height - Settings.ResolutionHeight) < 1f && Math.Abs(Screen.resolutions[i].refreshRate - Settings.ResolutionRefresh) < 1f)
                    currentIndex = i;

                options.Add(Screen.resolutions[i].ToString());
            }

            Resolutions = Screen.resolutions;
            ResolutionDropdown.ClearOptions();
            ResolutionDropdown.AddOptions(options);
            ResolutionDropdown.value = currentIndex;
            ResolutionDropdown.RefreshShownValue();
        }

        public void SetResolution(int index)
        {
            Screen.SetResolution(Resolutions[index].width, Resolutions[index].height, Screen.fullScreen);
            Settings.ResolutionWidth = Resolutions[index].width;
            Settings.ResolutionHeight = Resolutions[index].height;
            Settings.ResolutionRefresh = Resolutions[index].refreshRate;
        }

        public void LoadFullscreen()
        {
            Screen.fullScreen = Settings.Fullscreen;
            FullScreenToggle.isOn = Settings.Fullscreen;
        }

        public void SetFullscreen(bool isFullscreen)
        {
            Screen.fullScreen = isFullscreen;
            Settings.Fullscreen = isFullscreen;
        }
    }
}