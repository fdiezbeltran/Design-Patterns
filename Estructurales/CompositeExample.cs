using UnityEngine;
using System.Collections.Generic;

// Componente base
abstract class Component
{
    protected string name;

    public Component(string name)
    {
        this.name = name;
    }

    public abstract void Add(Component component);
    public abstract void Remove(Component component);
    public abstract void Display(int depth);
}

// Componente hoja
class Leaf : Component
{
    public Leaf(string name) : base(name)
    {
    }

    public override void Add(Component component)
    {
        Debug.LogError("No se pueden agregar componentes a una hoja.");
    }

    public override void Remove(Component component)
    {
        Debug.LogError("No se pueden remover componentes de una hoja.");
    }

    public override void Display(int depth)
    {
        Debug.Log(new string('-', depth) + name);
    }
}

// Componente compuesto
class Composite : Component
{
    private List<Component> children = new List<Component>();

    public Composite(string name) : base(name)
    {
    }

    public override void Add(Component component)
    {
        children.Add(component);
    }

    public override void Remove(Component component)
    {
        children.Remove(component);
    }

    public override void Display(int depth)
    {
        Debug.Log(new string('-', depth) + name);

        foreach (Component component in children)
        {
            component.Display(depth + 2);
        }
    }
}

// Clase de ejemplo de uso
public class CompositeExample : MonoBehaviour
{
    void Start()
    {
        // Crear la estructura del composite
        Composite root = new Composite("Raíz");
        root.Add(new Leaf("Hoja 1"));
        root.Add(new Leaf("Hoja 2"));

        Composite comp = new Composite("Compuesto 1");
        comp.Add(new Leaf("Hoja 3"));
        comp.Add(new Leaf("Hoja 4"));

        root.Add(comp);

        Leaf leaf = new Leaf("Hoja 5");
        root.Add(leaf);
        root.Remove(leaf);

        // Mostrar la estructura del composite
        root.Display(1);
    }
}
