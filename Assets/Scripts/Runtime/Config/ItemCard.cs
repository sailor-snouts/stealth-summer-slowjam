using UnityEngine;

namespace Scripts.Runtime.Config
{
    [CreateAssetMenu(fileName = "ItemCard", menuName = "Config/Cards/ItemCard", order = 0)]
    public class ItemCard : Card
    {
        public override Runtime.Player.Card.CardType Type { get => Runtime.Player.Card.CardType.Item; }
        [field: SerializeField] public int Damage { get; private set; }
    }
}