using UnityEngine;

// Producto: Clase para representar el sándwich
public class Sandwich
{
    public enum MeatType
    {
        Pollo,
        Pavo,
        Jamon
    }

    public enum BreadType
    {
        Integral,
        Blanco,
        Centeno
    }

    public enum SauceType
    {
        Mayonesa,
        Mostaza,
        Ketchup
    }

    public MeatType Meat { get; set; }
    public BreadType Bread { get; set; }
    public SauceType Sauce { get; set; }

    public void Display()
    {
        string meat = Meat.ToString();
        string bread = Bread.ToString();
        string sauce = Sauce.ToString();

        Debug.Log("Sándwich: " + meat + " en pan " + bread + " con salsa " + sauce);
    }
}

// Builder: Interfaz para construir el sándwich paso a paso
public interface ISandwichBuilder
{
    void SetMeat(Sandwich.MeatType meat);
    void SetBread(Sandwich.BreadType bread);
    void SetSauce(Sandwich.SauceType sauce);
    Sandwich GetSandwich();
}

// Concrete Builder: Implementación del constructor de sándwiches
public class SandwichBuilder : ISandwichBuilder
{
    private Sandwich sandwich;

    public SandwichBuilder()
    {
        sandwich = new Sandwich();
    }

    public void SetMeat(Sandwich.MeatType meat)
    {
        sandwich.Meat = meat;
    }

    public void SetBread(Sandwich.BreadType bread)
    {
        sandwich.Bread = bread;
    }

    public void SetSauce(Sandwich.SauceType sauce)
    {
        sandwich.Sauce = sauce;
    }

    public Sandwich GetSandwich()
    {
        return sandwich;
    }
}

// Director: Clase que construye el sándwich utilizando el Builder
public class SandwichMaker
{
    public Sandwich MakeSandwich(ISandwichBuilder builder, Sandwich.MeatType meat, Sandwich.BreadType bread, Sandwich.SauceType sauce)
    {
        builder.SetMeat(meat);
        builder.SetBread(bread);
        builder.SetSauce(sauce);
        return builder.GetSandwich();
    }
}

// BuilderExample: Clase principal que muestra el ejemplo de uso
public class BuilderExample : MonoBehaviour
{
    public Sandwich.MeatType meat;
    public Sandwich.BreadType bread;
    public Sandwich.SauceType sauce;

    void Start()
    {
        // Crear el director y el constructor de sándwiches
        SandwichMaker sandwichMaker = new SandwichMaker();
        SandwichBuilder sandwichBuilder = new SandwichBuilder();

        // Construir el sándwich utilizando las variables del inspector de Unity
        Sandwich sandwich = sandwichMaker.MakeSandwich(sandwichBuilder, meat, bread, sauce);

        // Mostrar el sándwich construido
        sandwich.Display();
    }
}
