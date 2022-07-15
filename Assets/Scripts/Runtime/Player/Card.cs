using UnityEngine;

namespace Scripts.Runtime.Player
{
    public class Card
    {
        public enum CardType { Creature, Spell, Equipment, Item }
        public enum CardRarity { Common, Uncommon, Rare, Epic, Legendary }

        public Sprite Image { get;}
        public CardRarity Rarity { get; }
        public string Name { get; }
        public string Description { get; }
        public int Cost { get; }

        public Card(int cost, CardRarity rarity, string name, string description, Sprite image)
        {
            Image = image;
            Rarity = rarity;
            Name = name;
            Description = description;
            Cost = cost;
        }
    }
}