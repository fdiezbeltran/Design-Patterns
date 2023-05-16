using UnityEngine;

// Interfaz base del componente Hamburguesa
public interface IHamburger
{
    string GetDescription();
    float GetPrice();
}

// Clase base de la Hamburguesa Simple
public class SimpleHamburger : IHamburger
{
    public string GetDescription()
    {
        return "Hamburguesa Simple";
    }

    public float GetPrice()
    {
        return 5.0f;
    }
}

// Decorador base
public abstract class HamburgerDecorator : IHamburger
{
    protected IHamburger _hamburger;

    public HamburgerDecorator(IHamburger hamburger)
    {
        _hamburger = hamburger;
    }

    public virtual string GetDescription()
    {
        return _hamburger.GetDescription();
    }

    public virtual float GetPrice()
    {
        return _hamburger.GetPrice();
    }
}

// Decorador con funcionalidad adicional: agregamos queso a la hamburguesa
public class CheeseDecorator : HamburgerDecorator
{
    private float _cheesePrice;

    public CheeseDecorator(IHamburger hamburger) : base(hamburger)
    {
        _cheesePrice = 1.0f;
    }

    public override string GetDescription()
    {
        return base.GetDescription() + ", Queso";
    }

    public override float GetPrice()
    {
        return base.GetPrice() + _cheesePrice;
    }
}

// Decorador con funcionalidad adicional: agregamos bacon a la hamburguesa
public class BaconDecorator : HamburgerDecorator
{
    private float _baconPrice;

    public BaconDecorator(IHamburger hamburger) : base(hamburger)
    {
        _baconPrice = 2.0f;
    }

    public override string GetDescription()
    {
        return base.GetDescription() + ", Bacon";
    }

    public override float GetPrice()
    {
        return base.GetPrice() + _baconPrice;
    }
}

// Clase de ejemplo para usar el patrón Decorator
public class DecoratorExample : MonoBehaviour
{
    public bool addCheese;
    public bool addBacon;

    private void Start()
    {
        // Creamos una hamburguesa simple
        IHamburger hamburger = new SimpleHamburger();

        // Agregamos los decoradores según las selecciones en el inspector
        if (addCheese)
        {
            hamburger = new CheeseDecorator(hamburger);
        }

        if (addBacon)
        {
            hamburger = new BaconDecorator(hamburger);
        }

        // Obtenemos la descripción y el precio de la hamburguesa decorada
        string description = hamburger.GetDescription();
        float price = hamburger.GetPrice();

        // Mostramos la descripción y el precio en la consola
        Debug.Log("Descripción de la hamburguesa: " + description);
        Debug.Log("Precio de la hamburguesa: $" + price);
    }
}
