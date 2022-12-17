using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

public enum Expansion
{
    BASE_SET
}

public enum Rarity
{
    COMMON,
    UNCOMMON,
    RARE,
    EPIC,
    LEGENDARY
}

public class Card : ScriptableObject
{
    public int ID;
    public string Name;
    public int ManaCost;
    public Sprite Artwork;
    public Expansion Expansion;
    public Rarity Rarity;
    [HideInInspector]
    public Player Owner;
    public List<Effect> Effects;

    public virtual void ResolveEffects() {}
    public virtual void OnPlay(Player owner, Player opponent, Table table) {}
}


