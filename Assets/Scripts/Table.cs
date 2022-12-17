using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public List<Card> CardsOnTable;

    public Table()
    {
        CardsOnTable = new List<Card>();
    }

    public void AddCard(Card card)
    {
        CardsOnTable.Add(card);
    }

    public void RemoveCard(Card card)
    {
        CardsOnTable.Remove(card);
    }

    public void Clear()
    {
        CardsOnTable.Clear();
    }
    public void ResolveEffects()
    {
        foreach (Card card in CardsOnTable)
        {
            card.ResolveEffects();
        }
    }

}