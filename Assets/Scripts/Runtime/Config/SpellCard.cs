using UnityEngine;

namespace Scripts.Runtime.Config
{
    [CreateAssetMenu(fileName = "SpellCard", menuName = "Config/Cards/SpellCard", order = 0)]
    public class SpellCard : Card
    {
        public override Runtime.Player.Card.CardType Type { get => Runtime.Player.Card.CardType.Spell; }
        [field: SerializeField] public int Damage { get; private set; }
    }
}