using UnityEngine;

namespace Scripts.Runtime.Config
{
    [CreateAssetMenu(fileName = "Credit", menuName = "Config/Credits", order = 0)]
    public class CreditsData : ScriptableObject
    {
        [field: SerializeField] public Credit.CreditName[] People { get; private set; }
    }
}