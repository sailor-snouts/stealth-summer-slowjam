using System;
using Scripts.Runtime.Player;
using UnityEngine;

namespace Scripts.Runtime.Controller
{
    public class PlayerController : MonoBehaviour
    {
        [field: SerializeField] public Config.Player Player { get; private set; } = null;

        public Deck Deck { get; private set; } = null;

        private void Start()
        {
            Deck = new Deck(Player.Cards);
        }
    }
}