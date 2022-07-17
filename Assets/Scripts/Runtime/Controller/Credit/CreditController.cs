using System.Linq;
using TMPro;
using UnityEngine;

namespace Scripts.Runtime.Controller.Credit
{
    public class CreditController : MonoBehaviour
    {
        [field: SerializeField] private TMP_Text Position { get; set; }
        [field: SerializeField] private TMP_Text Names { get; set; }

        public void SetCredit(Runtime.Credit.CreditRole creditRole)
        {
            Position.text = creditRole.Role;
            Names.text = creditRole.Names.Aggregate((s, s1) => s + "\n" + s1);
        }
    }
}