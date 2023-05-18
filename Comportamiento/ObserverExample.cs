using System;
using UnityEngine;

// Interfaz del observador
public interface IObserver
{
    void Update();
}

// Clase de uso que actúa como el sujeto observado
public class Subject
{
    private int data;
    private event Action OnDataChanged;

    public int Data
    {
        get { return data; }
        set
        {
            data = value;
            NotifyObservers();
        }
    }

    public void Attach(IObserver observer)
    {
        OnDataChanged += observer.Update;
    }

    public void Detach(IObserver observer)
    {
        OnDataChanged -= observer.Update;
    }

    private void NotifyObservers()
    {
        if (OnDataChanged != null)
        {
            OnDataChanged.Invoke();
        }
    }
}

// Clase de ejemplo que implementa la interfaz IObserver
public class ObserverExample : MonoBehaviour, IObserver
{
    private Subject subject;

    private void Start()
    {
        subject = new Subject();
        subject.Attach(this);
    }

    public void Update()
    {
        Debug.Log("El valor de data ha cambiado: " + subject.Data);
    }

    private void OnDestroy()
    {
        subject.Detach(this);
    }
}