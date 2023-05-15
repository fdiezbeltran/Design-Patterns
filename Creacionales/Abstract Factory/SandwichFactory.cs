using UnityEngine;
// Fábrica abstracta
public abstract class SandwichFactory
{
    public abstract Sandwich CreateSandwich();
    public abstract Drink CreateDrink();
}
