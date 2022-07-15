using UnityEngine;

namespace Scripts.Runtime.Config
{
    public abstract class Card : ScriptableObject
    {
        public abstract Runtime.Player.Card.CardType Type { get; }
        [field: SerializeField] public Sprite Image { get; private set; }
        [field: SerializeField] public Runtime.Player.Card.CardRarity Rarity { get; private set; } = Runtime.Player.Card.CardRarity.Common;
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public int Cost { get; private set; }
    }
}