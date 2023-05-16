using UnityEngine;

// Subsistemas complejos
class SubsystemA
{
    public void OperationA()
    {
        Debug.Log("Subsystem A operation");
    }
}

class SubsystemB
{
    public void OperationB()
    {
        Debug.Log("Subsystem B operation");
    }
}

class SubsystemC
{
    public void OperationC()
    {
        Debug.Log("Subsystem C operation");
    }
}

// Fachada
class Facade
{
    private SubsystemA subsystemA;
    private SubsystemB subsystemB;
    private SubsystemC subsystemC;

    public Facade()
    {
        subsystemA = new SubsystemA();
        subsystemB = new SubsystemB();
        subsystemC = new SubsystemC();
    }

    public void OperationA()
    {
        Debug.Log("Facade operation A");
        subsystemA.OperationA();
    }

    public void OperationB()
    {
        Debug.Log("Facade operation B");
        subsystemB.OperationB();
    }

    public void OperationC()
    {
        Debug.Log("Facade operation C");
        subsystemC.OperationC();
    }
}

// Clase de uso (ejemplo)
public class FacadeExample : MonoBehaviour
{
    public enum SubsystemType
    {
        SubsystemA,
        SubsystemB,
        SubsystemC
    }

    public SubsystemType selectedSubsystem;

    private Facade facade;

    private void Start()
    {
        facade = new Facade();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Llamando a la operación correspondiente según el subsistema seleccionado
            switch (selectedSubsystem)
            {
                case SubsystemType.SubsystemA:
                    facade.OperationA();
                    break;
                case SubsystemType.SubsystemB:
                    facade.OperationB();
                    break;
                case SubsystemType.SubsystemC:
                    facade.OperationC();
                    break;
            }
        }
    }
}
