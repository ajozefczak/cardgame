using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player1;
    public Player player2;
    public Table table;

    public static GameManager Instance { get; private set; }

    void Start()
    {
        // Initialize the game
        player1.Deck.Shuffle();
        player2.Deck.Shuffle();
        player1.DrawCards(5);
        player2.DrawCards(5);
        table.Clear();
    }

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        // Check for game over conditions
        if (player1.IsDefeated())
        {
            Debug.Log("Player 2 wins!");
        }
        else if (player2.IsDefeated())
        {
            Debug.Log("Player 1 wins!");
        }
    }

    public Player GetPlayer(int playerNumber)
    {
        if (playerNumber == 1)
        {
            return player1;
        }
        else if (playerNumber == 2)
        {
            return player2;
        }
        else
        {
            return null;
        }
    }

    public void EndTurn()
    {
        // End the current player's turn and start the next player's turn
        if (player1.isTurn)
        {
            player1.isTurn = false;
            player2.isTurn = true;
        }
        else
        {
            player1.isTurn = true;
            player2.isTurn = false;
        }

        // Resolve any effects on the table
        table.ResolveEffects();
    }

    public void PlayCard(int playerNumber, int cardIndex)
    {
        // Get the player who is trying to play the card
        Player player = GetPlayer(playerNumber);

        // Check if it is the player's turn
        if (player.isTurn)
        {
            // Get the card that the player is trying to play
            Card card = player.Hand[cardIndex];

            // Check if the player has enough energy to play the card
            if (player.Mana >= card.ManaCost)
            {
                // Decrease the player's energy by the card's cost
                player.Mana -= card.ManaCost;

                // Play the card
                card.OnPlay(player, player2, table);

                // Remove the card from the player's hand
                player.Hand.RemoveAt(cardIndex);
            }
            else
            {
                // The player does not have enough energy to play the card
                Debug.Log("Not enough mana to play this card.");
            }
        }
        else
        {
            // It is not the player's turn
            Debug.Log("It is not your turn.");
        }
    }
}
