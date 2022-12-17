using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    public string Name;
    public int Health;
    public Deck Deck;
    public List<Card> Hand;
    public bool isTurn;
    public int Mana;
    public int MaxHealth = 20;

    public Player(string name, int health, Deck deck, List<Card> hand)
    {
        Name = name;
        Health = MaxHealth;
        Deck = deck;
        Hand = hand;
        Mana = 0;
    }

    public bool IsDefeated()
    {
        return Health <= 0;
    }

    public void DrawCards(int numCards)
    {
        for (int i = 0; i < numCards; i++)
        {
            Card drawnCard = Deck.DrawCard();
            if (drawnCard != null)
            {
                Hand.Add(drawnCard);
            }
        }
    }
}
