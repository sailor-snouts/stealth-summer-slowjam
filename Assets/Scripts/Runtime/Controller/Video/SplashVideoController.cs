using Scripts.Runtime.Controller.Animation;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

namespace Scripts.Runtime.Controller.Video
{
    [RequireComponent(typeof(VideoPlayer))]
    public class SplashVideoController : MonoBehaviour
    {
        [field: SerializeField] private string FilePath { get; set; }
        [field: SerializeField] private string NextScene { get; set; }
        [field: SerializeField] private InputActionReference ContinueInput { get; set; }
        [field: SerializeField] private SceneTransitionController TransitionController { get; set; }
        private VideoPlayer VideoPlayer { get; set; }

        private void OnEnable()
        {
            VideoPlayer = GetComponent<VideoPlayer>();
            VideoPlayer.source = VideoSource.Url;
            VideoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, FilePath);
            VideoPlayer.Prepare();
            VideoPlayer.prepareCompleted += OnPrepareCompleted;
            VideoPlayer.loopPointReached += OnLoopPointReached;
            ContinueInput.action.performed += OnContinue;
        }

        private void OnDisable()
        {
            VideoPlayer.prepareCompleted -= OnPrepareCompleted;
            VideoPlayer.loopPointReached -= OnLoopPointReached;
            ContinueInput.action.performed -= OnContinue;
        }

        private void OnPrepareCompleted(VideoPlayer source)
        {
            VideoPlayer.Play();
        }

        private void OnContinue(InputAction.CallbackContext obj)
        {
            Debug.Log("Skip");
            if (!VideoPlayer.isPlaying) return;
            LoadNextScene();
        }

        private void OnLoopPointReached(VideoPlayer source)
        {
            LoadNextScene();
        }

        private void LoadNextScene()
        {
            VideoPlayer.Stop();
            Destroy(gameObject);
            TransitionController.Transition(NextScene);
        }
    }
}