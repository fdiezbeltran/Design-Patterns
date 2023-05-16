using UnityEngine;

// Interfaz que define las operaciones que el Proxy y el Objeto Real deben implementar
public interface IResource
{
    void Request();
}

// Clase concreta que representa el Objeto Real
public class RealResource : IResource
{
    public void Request()
    {
        Debug.Log("RealResource: Procesando la solicitud.");
    }
}

// Clase Proxy que controla el acceso al Objeto Real
public class ResourceProxy : IResource
{
    private RealResource realResource;

    public void Request()
    {
        // Verificar si se ha creado el Objeto Real y crearlo si no existe
        if (realResource == null)
        {
            Debug.Log("ResourceProxy: Creando el Objeto Real.");
            realResource = new RealResource();
        }

        // Realizar acciones adicionales antes o después de llamar al Objeto Real
        Debug.Log("ResourceProxy: Verificando la autenticación del usuario.");
        Debug.Log("ResourceProxy: Verificando los permisos de acceso.");

        // Llamar al método del Objeto Real
        realResource.Request();

        // Realizar acciones adicionales después de llamar al Objeto Real
        Debug.Log("ResourceProxy: Registrando la solicitud.");
    }
}

// Clase de ejemplo para utilizar el Proxy
public class ProxyExample : MonoBehaviour
{
    private void Start()
    {
        // Crear una instancia del Proxy
        IResource resource = new ResourceProxy();

        // Realizar la solicitud a través del Proxy
        resource.Request();
    }
}
