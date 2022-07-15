using UnityEngine;

namespace Scripts.Runtime.Config
{
    [CreateAssetMenu(fileName = "CreatureCard", menuName = "Config/Cards/CreatureCard", order = 0)]
    public class CreatureCard : Card
    {
        public override Runtime.Player.Card.CardType Type { get => Runtime.Player.Card.CardType.Creature; }
        [field: SerializeField] public int Health { get; private set; }
        [field: SerializeField] public int Attack { get; private set; }
        [field: SerializeField] public int Move { get; private set; }
    }
}