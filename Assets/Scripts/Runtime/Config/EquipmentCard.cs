using UnityEngine;

namespace Scripts.Runtime.Config
{
    [CreateAssetMenu(fileName = "EquipmentCard", menuName = "Config/Cards/EquipmentCard", order = 0)]
    public class EquipmentCard : Card
    {
        public override Runtime.Player.Card.CardType Type { get => Runtime.Player.Card.CardType.Equipment; }
        [SerializeField] public int Defence { get; private set; }
        [SerializeField] public int Attack { get; private set; }
    }
}