using DG.Tweening;
using UnityEngine;
using UnityEngine.Audio;

namespace Scripts.Runtime.Controller.Animation
{
    public class SceneFade
    {
        private CanvasGroup CanvasGroup { get; }
        private AudioMixer AudioMixer { get; }
        private Tween CanvasTween { get; set; }
        private Tween AudioTween { get; set; }

        public SceneFade(CanvasGroup canvasGroup, AudioMixer audioMixer)
        {
            CanvasGroup = canvasGroup;
            AudioMixer = audioMixer;
        }

        public void FadeIn(float duration, TweenCallback onComplete)
        {
            Fade(1f, duration, () =>
            {
                CanvasGroup.interactable = true;
                CanvasGroup.blocksRaycasts = true;
            });
            CanvasTween.onComplete += onComplete;
        }

        public void FadeOut(float duration, TweenCallback onComplete)
        {
            Fade(0f, duration, () =>
            {
                CanvasGroup.interactable = false;
                CanvasGroup.blocksRaycasts = false;
            });
            CanvasTween.onComplete += onComplete;
        }

        private void Fade(float value, float duration, TweenCallback onComplete)
        {
            if (CanvasGroup != null)
            {
                if (CanvasTween != null) CanvasTween.Kill();

                CanvasTween = CanvasGroup.DOFade(value, duration);
                CanvasTween.onComplete += onComplete;
            }

            if (AudioMixer != null)
            {
                if (AudioTween != null) AudioTween.Kill();

                AudioTween = AudioMixer.DOSetFloat("MainVolume", value, duration);
                AudioTween.onComplete = onComplete;
            }
        }
    }
}