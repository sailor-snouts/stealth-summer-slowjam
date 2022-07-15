using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Runtime.Config
{
    [CreateAssetMenu(fileName = "Player", menuName = "Config/Player", order = 0)]
    public class Player : ScriptableObject
    {
        [field: SerializeField] public Sprite Image { get; private set; }
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public List<Card> Cards { get; private set; }
    }
}