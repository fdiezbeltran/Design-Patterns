using UnityEngine;
using System;

// Clase de Origen
public class Originator
{
    private string state;

    public void SetState(string state)
    {
        Debug.Log("Originator: Estableciendo estado a " + state);
        this.state = state;
    }

    public Memento CreateMemento()
    {
        Debug.Log("Originator: Creando Memento...");
        return new Memento(state);
    }

    public void RestoreMemento(Memento memento)
    {
        state = memento.GetState();
        Debug.Log("Originator: Estado restaurado a " + state);
    }
}

// Clase Memento
public class Memento
{
    private string state;

    public Memento(string state)
    {
        this.state = state;
    }

    public string GetState()
    {
        return state;
    }
}

// Clase Caretaker
public class Caretaker
{
    private Memento memento;

    public Memento GetMemento()
    {
        return memento;
    }

    public void SetMemento(Memento memento)
    {
        this.memento = memento;
    }
}

// Clase de ejemplo
public class MementoExample : MonoBehaviour
{
    void Start()
    {
        Originator originator = new Originator();
        Caretaker caretaker = new Caretaker();

        originator.SetState("Estado 1");
        caretaker.SetMemento(originator.CreateMemento());

        originator.SetState("Estado 2");

        // Restaurar el estado original
        originator.RestoreMemento(caretaker.GetMemento());
    }
}
