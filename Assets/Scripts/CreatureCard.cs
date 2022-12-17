using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum CreatureSubtype
{
    NONE,
    SAMURAI,
    HUMAN,
    FOX
}

[CreateAssetMenu(menuName = "Card/Creature")]
public class CreatureCard : Card
{
    public int Attack;
    public int CurrentHealth;
    public int MaxHealth;
    public List<CreatureSubtype> Subtype;

    public override void ResolveEffects()
    {
        foreach (Effect effect in Effects)
        {
            effect.Resolve();
        }
    }

    public override void OnPlay(Player owner, Player opponent, Table table)
    {
        Owner = owner;
        table.CardsOnTable.Add(this);
        ResolveEffects();
    }
}
