using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealEffect : Effect
{
    public int Target { get; set; }
    public int Amount { get; set; }

    public HealEffect(int target, int amount)
    {
        Target = target;
        Amount = amount;
    }

    public override void Resolve()
    {
        // Get the player object to be healed
        Player player = GameManager.Instance.GetPlayer(Target);

        // Heal the player by the specified amount
        player.Health += Amount;

        // Clamp the player's health to a maximum value
        player.Health = Mathf.Clamp(player.Health, 0, player.MaxHealth);
    }
}
