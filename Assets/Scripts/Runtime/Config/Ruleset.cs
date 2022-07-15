using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Runtime.Config
{
    [CreateAssetMenu(fileName = "Ruleset", menuName = "Config/RuleSet", order = 0)]
    public class Ruleset : ScriptableObject
    {
        [field: Header("Player")]
        [field: SerializeField] public List<Player> Players { get; private set; }= new List<Player>();

        [field: Header("Supplies")]
        [field: SerializeField] public int StartingSupplies { get; private set; } = 20;
        [field: SerializeField] public int SuppliesPerTurn { get; private set; } = 2;

        [field: Header("Rarity")]
        [field: SerializeField] public int CommonDrawChance { get; private set; } = 8;
        [field: SerializeField] public int UncommonDrawChance { get; private set; } = 6;
        [field: SerializeField] public int RareDrawChance { get; private set; } = 3;
        [field: SerializeField] public int EpicDrawChance { get; private set; } = 2;
        [field: SerializeField] public int LegendaryDrawChance { get; private set; } = 1;
        
        [field: Header("Collisions")]
        [field: SerializeField] public LayerMask UnitMask { get; private set; } = 0;
        [field: SerializeField] public LayerMask GroundMask { get; private set; } = 0;
        [field: SerializeField] public LayerMask BlockPathMask { get; private set; } = 0;
        [field: SerializeField] public LayerMask InteractableMask { get; private set; } = 0;
        [field: SerializeField] public LayerMask CardMask { get; private set; } = 0;
    }
}