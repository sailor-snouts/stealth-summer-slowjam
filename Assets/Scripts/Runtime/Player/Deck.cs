using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace Scripts.Runtime.Player
{
    public class Deck
    {
        private Dictionary<Card.CardRarity, List<Card>> Cards { get; set; } = new Dictionary<Card.CardRarity, List<Card>>();
        private int CommonDrawChance { get; set; } = 8;
        private int UncommonDrawChance { get; set; } = 6;
        private int RareDrawChance { get; set; } = 3;
        private int EpicDrawChance { get; set; } = 2;
        private int LegendaryDrawChance { get; set; } = 1;
        private int ChanceSum { get => CommonDrawChance + UncommonDrawChance + RareDrawChance + EpicDrawChance + LegendaryDrawChance; }

        public Deck(List<Config.Card> cards)
        {
            foreach (var card in cards)
                AddCard(new Card(card.Cost, card.Rarity, card.Name, card.Description, card.Image));
        }

        public void AddCard(Card card)
        {
            if (!Cards.ContainsKey(card.Rarity))
            {
                Cards.Add(card.Rarity, new List<Card>());
            }

            Cards[card.Rarity].Add(card);
        }

        public Card DrawCard()
        {
            int roll = Random.Range(0, ChanceSum);
            roll -= LegendaryDrawChance;
            if (roll < 0) return DrawCard(Card.CardRarity.Legendary);
            roll -= EpicDrawChance;
            if (roll < 0) return DrawCard(Card.CardRarity.Epic);
            roll -= RareDrawChance;
            if (roll < 0) return DrawCard(Card.CardRarity.Rare);
            roll -= UncommonDrawChance;
            if (roll < 0) return DrawCard(Card.CardRarity.Uncommon);

            return DrawCard(Card.CardRarity.Common);
        }

        private Card DrawCard(Card.CardRarity rarity)
        {
            List<Card> cards = Cards[rarity];
            int index = Random.Range(0, cards.Count);

            return cards[index];
        }
    }
}