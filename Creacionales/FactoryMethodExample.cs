using UnityEngine;

// Producto: interfaz para representar los diferentes tipos de sándwiches
public interface ISandwich
{
    void Prepare();
    void AddIngredients();
    void AddCondiments();
}

// Producto concreto: implementación de un tipo de sándwich
public class HamSandwich : ISandwich
{
    public void Prepare()
    {
        Debug.Log("Preparando pan y jamón para el sándwich de jamón.");
    }

    public void AddIngredients()
    {
        Debug.Log("Agregando lechuga y tomate al sándwich de jamón.");
    }

    public void AddCondiments()
    {
        Debug.Log("Agregando mayonesa y mostaza al sándwich de jamón.");
    }
}

// Producto concreto: implementación de otro tipo de sándwich
public class TurkeySandwich : ISandwich
{
    public void Prepare()
    {
        Debug.Log("Preparando pan y pavo para el sándwich de pavo.");
    }

    public void AddIngredients()
    {
        Debug.Log("Agregando queso y vegetales al sándwich de pavo.");
    }

    public void AddCondiments()
    {
        Debug.Log("Agregando aderezo y especias al sándwich de pavo.");
    }
}

public class CheeseSandwich : ISandwich
{
    public void Prepare()
    {
        Debug.Log("Preparando pan y queso para el sándwich de queso.");
    }

    public void AddIngredients()
    {
        Debug.Log("Agregando cebolla y tomate al sándwich de queso.");
    }

    public void AddCondiments()
    {
        Debug.Log("Agregando chimichurri al sándwich de queso.");
    }
}

// Creador abstracto: define el método de fábrica
public abstract class SandwichFactoryAbstract
{
    public abstract ISandwich CreateSandwich();

    // Método jugable para utilizar el sándwich creado
    public void Play()
    {
        ISandwich sandwich = CreateSandwich();

        sandwich.Prepare();
        sandwich.AddIngredients();
        sandwich.AddCondiments();

        Debug.Log("¡El sándwich está listo!");
    }
}

// Creador concreto: implementación de una fábrica de sándwiches
public class SandwichFactory : SandwichFactoryAbstract
{
    private SandwichType sandwichType; // Tipo de sándwich seleccionado en el inspector

    public SandwichFactory(SandwichType type)
    {
        sandwichType = type;
    }

    public override ISandwich CreateSandwich()
    {
        switch (sandwichType)
        {
            case SandwichType.Ham:
                return new HamSandwich();
            case SandwichType.Turkey:
                return new TurkeySandwich();
            case SandwichType.Cheese:
                return new CheeseSandwich();
            default:
                Debug.LogError("Tipo de sándwich no válido.");
                return null;
        }
    }
}


// Enum para elegir el tipo de sándwich en el inspector de Unity
public enum SandwichType
{
    Ham,
    Turkey,
    Cheese
}
// Clase de ejemplo para mostrar el uso del patrón Factory Method en Unity
public class FactoryMethodExample : MonoBehaviour
{
    public SandwichType sandwichType; // Tipo de sándwich seleccionado en el inspector

    private SandwichFactory factory;

    private void Start()
    {
        // Creamos la fábrica de sándwiches con el tipo seleccionado en el inspector
        factory = new SandwichFactory(sandwichType);

        // Utilizamos la fábrica para jugar y crear el sándwich correspondiente
        factory.Play();
    }
}
