using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

namespace Scripts.Runtime.Controller.Animation
{
    public class SceneTransitionController : MonoBehaviour
    {
        [field: SerializeField] private CanvasGroup CanvasGroup { get; set; }
        [field: SerializeField] private AudioMixer AudioMixer { get; set; }
        private SceneFade Fade { get; set; }

        private void OnEnable()
        {
            Fade = new SceneFade(CanvasGroup, AudioMixer);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        
        private void OnDisable()
        {
            Fade = null;
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            Fade.FadeOut(1f, () => { });
        }

        public void Transition(string sceneName)
        {
            Fade.FadeIn(1f, () => SceneManager.LoadScene(sceneName));
        }
    }
}