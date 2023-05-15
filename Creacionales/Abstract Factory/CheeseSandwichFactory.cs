using UnityEngine;
// Fábrica concreta para sándwiches de queso y jugo
public class CheeseSandwichFactory : SandwichFactory
{
    public override Sandwich CreateSandwich()
    {
        return new CheeseSandwich();
    }

    public override Drink CreateDrink()
    {
        return new Juice();
    }
}
