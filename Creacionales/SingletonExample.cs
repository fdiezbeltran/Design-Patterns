using UnityEngine;

public class SingletonExample : MonoBehaviour
{
    private static SingletonExample instance;

    // Este es el método público estático que devuelve la instancia única.
    public static SingletonExample Instance
    {
        get
        {
            // Si la instancia aún no ha sido creada, la creamos.
            if (instance == null)
            {
                // Buscamos la instancia en la escena.
                instance = FindObjectOfType<SingletonExample>();

                // Si no encontramos ninguna instancia en la escena, la creamos.
                if (instance == null)
                {
                    // Creamos un nuevo GameObject que contendrá la instancia.
                    GameObject singletonObject = new GameObject("SingletonExample");
                    // Añadimos la clase SingletonExample al GameObject.
                    instance = singletonObject.AddComponent<SingletonExample>();
                }
            }

            // Devolvemos la instancia única.
            return instance;
        }
    }

    // Este método es un ejemplo de lo que puede hacer la clase SingletonExample.
    public void SomeMethod()
    {
        Debug.Log("¡Hola! Soy la instancia única de SingletonExample.");
    }

    // Aseguramos que no se puedan crear instancias adicionales de la clase SingletonExample.
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
