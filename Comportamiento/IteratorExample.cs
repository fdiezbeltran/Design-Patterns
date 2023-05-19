using System;
using System.Collections;
using UnityEngine;

// Clase que representa el elemento iterable
public class Aggregate : IEnumerable
{
    private int[] items;

    public Aggregate()
    {
        items = new int[3] { 1, 2, 3 };
    }

    // Método para obtener el iterador
    public IEnumerator GetEnumerator()
    {
        return new Iterator(items);
    }
}

// Clase que representa el iterador
public class Iterator : IEnumerator
{
    private int[] items;
    private int position = -1;

    public Iterator(int[] items)
    {
        this.items = items;
    }

    // Método para avanzar al siguiente elemento
    public bool MoveNext()
    {
        position++;
        return (position < items.Length);
    }

    // Método para reiniciar el iterador
    public void Reset()
    {
        position = -1;
    }

    // Propiedad para obtener el elemento actual
    public object Current
    {
        get { return items[position]; }
    }
}

// Clase de ejemplo que utiliza el patrón de diseño Iterator
public class IteratorExample : MonoBehaviour
{
    private void Start()
    {
        Aggregate aggregate = new Aggregate();

        // Iterar sobre los elementos utilizando el iterador
        foreach (int item in aggregate)
        {
            Debug.Log(item);
        }
    }
}
