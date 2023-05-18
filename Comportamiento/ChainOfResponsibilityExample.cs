using UnityEngine;

// Clase base para las solicitudes
public abstract class PurchaseRequest
{
    public float Amount { get; private set; }

    public PurchaseRequest(float amount)
    {
        Amount = amount;
    }
}

// Clase concreta para una solicitud de compra de bajo nivel
public class LowLevelPurchaseRequest : PurchaseRequest
{
    public LowLevelPurchaseRequest(float amount) : base(amount) { }
}

// Clase concreta para una solicitud de compra de nivel medio
public class MediumLevelPurchaseRequest : PurchaseRequest
{
    public MediumLevelPurchaseRequest(float amount) : base(amount) { }
}

// Clase concreta para una solicitud de compra de alto nivel
public class HighLevelPurchaseRequest : PurchaseRequest
{
    public HighLevelPurchaseRequest(float amount) : base(amount) { }
}

// Manejador abstracto
public abstract class PurchaseHandler
{
    protected PurchaseHandler successor;

    public void SetSuccessor(PurchaseHandler successor)
    {
        this.successor = successor;
    }

    public virtual void HandleRequest(PurchaseRequest request)
    {
        if (successor != null)
        {
            successor.HandleRequest(request);
        }
    }
}

// Manejador concreto para solicitudes de compra de bajo nivel
public class LowLevelPurchaseHandler : PurchaseHandler
{
    public override void HandleRequest(PurchaseRequest request)
    {
        if (request.Amount <= 100.0f)
        {
            Debug.Log("Low Level Purchase Request Handled");
        }
        else
        {
            base.HandleRequest(request);
        }
    }
}

// Manejador concreto para solicitudes de compra de nivel medio
public class MediumLevelPurchaseHandler : PurchaseHandler
{
    public override void HandleRequest(PurchaseRequest request)
    {
        if (request.Amount <= 1000.0f)
        {
            Debug.Log("Medium Level Purchase Request Handled");
        }
        else
        {
            base.HandleRequest(request);
        }
    }
}

// Manejador concreto para solicitudes de compra de alto nivel
public class HighLevelPurchaseHandler : PurchaseHandler
{
    public override void HandleRequest(PurchaseRequest request)
    {
        if (request.Amount > 1000.0f)
        {
            Debug.Log("High Level Purchase Request Handled");
        }
        else
        {
            base.HandleRequest(request);
        }
    }
}

// Clase de ejemplo para utilizar el patrón Chain of Responsibility
public class ChainOfResponsibilityExample : MonoBehaviour
{
    private void Start()
    {
        // Configurar la cadena de manejadores
        PurchaseHandler lowLevelHandler = new LowLevelPurchaseHandler();
        PurchaseHandler mediumLevelHandler = new MediumLevelPurchaseHandler();
        PurchaseHandler highLevelHandler = new HighLevelPurchaseHandler();

        lowLevelHandler.SetSuccessor(mediumLevelHandler);
        mediumLevelHandler.SetSuccessor(highLevelHandler);

        // Ejemplos de solicitudes de compra
        PurchaseRequest request1 = new LowLevelPurchaseRequest(50.0f);
        PurchaseRequest request2 = new MediumLevelPurchaseRequest(500.0f);
        PurchaseRequest request3 = new HighLevelPurchaseRequest(1500.0f);

        // Procesar las solicitudes
        lowLevelHandler.HandleRequest(request1);
        lowLevelHandler.HandleRequest(request2);
        lowLevelHandler.HandleRequest(request3);
    }
}
