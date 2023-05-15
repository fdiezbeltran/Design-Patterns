using UnityEngine;

// Cliente
public class SandwichMaker : MonoBehaviour
{
    private SandwichFactory factory;

    private Sandwich sandwich;
    private Drink drink;

    public enum SandwichChoice{ HamSandwich, CheeseSandwich }
    public SandwichChoice sandwichChoice;
    
    private void Start()
    {
        if(sandwichChoice == SandwichChoice.HamSandwich)
        {
            // Crear una fábrica de sándwiches de jamón
            factory = new HamSandwichFactory();
        }
        if(sandwichChoice == SandwichChoice.CheeseSandwich)
        {
            // Crear una fábrica de sándwiches de jamón
            factory = new CheeseSandwichFactory();
        }

        // Pedir un sándwich y una bebida a la fábrica
        sandwich = factory.CreateSandwich();
        drink = factory.CreateDrink();

        // Preparar el sándwich y servir la bebida
        sandwich.Prepare();
        drink.Serve();
    }
}
