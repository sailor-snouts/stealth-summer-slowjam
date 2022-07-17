using Scripts.Runtime.Config;
using Scripts.Runtime.Controller.Animation;
using Scripts.Runtime.Credit;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Scripts.Runtime.Controller.Credit
{
    public class CreditsController : MonoBehaviour
    {
        [field: Header("Settings")]
        [field: SerializeField] private CreditsData CreditsData { get; set; }
        [field: SerializeField] private Transform CreditsRoot { get; set; }
        [field: SerializeField] private CreditController CreditTemplate { get; set; }

        [field: Header("Transition")]
        [field: SerializeField] private string NextScene { get; set; }
        [field: SerializeField] private InputActionReference ContinueInput { get; set; }
        [field: SerializeField] private SceneTransitionController TransitionController { get; set; }

        private void Start()
        {
            Credits credits = new Credits(CreditsData.People);
            foreach (CreditRole creditRole in credits.GroupedByRole())
            {
                CreditController creditController = Instantiate(CreditTemplate, CreditsRoot);
                creditController.SetCredit(creditRole);
            }
        }

        private void OnEnable()
        {
            ContinueInput.action.performed += OnContinue;
        }

        private void OnDisable()
        {
            ContinueInput.action.performed -= OnContinue;
        }

        private void OnContinue(InputAction.CallbackContext obj)
        {
            LoadNextScene();
        }

        private void LoadNextScene()
        {
            TransitionController.Transition(NextScene);
        }
    }
}