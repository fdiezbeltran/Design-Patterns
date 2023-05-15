using UnityEngine;
// Fábrica concreta para sándwiches de jamón y refresco
public class HamSandwichFactory : SandwichFactory
{
    public override Sandwich CreateSandwich()
    {
        return new HamSandwich();
    }

    public override Drink CreateDrink()
    {
        return new Soda();
    }
}
