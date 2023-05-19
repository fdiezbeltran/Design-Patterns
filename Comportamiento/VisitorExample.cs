using UnityEngine;

// Element interface
interface IElement
{
    void Accept(IVisitor visitor);
}

// Concrete element
class ConcreteElementA : IElement
{
    public void Accept(IVisitor visitor)
    {
        visitor.VisitElementA(this);
    }

    public void OperationA()
    {
        Debug.Log("ConcreteElementA.OperationA()");
    }
}

// Concrete element
class ConcreteElementB : IElement
{
    public void Accept(IVisitor visitor)
    {
        visitor.VisitElementB(this);
    }

    public void OperationB()
    {
        Debug.Log("ConcreteElementB.OperationB()");
    }
}

// Visitor interface
interface IVisitor
{
    void VisitElementA(ConcreteElementA elementA);
    void VisitElementB(ConcreteElementB elementB);
}

// Concrete visitor
class ConcreteVisitor : IVisitor
{
    public void VisitElementA(ConcreteElementA elementA)
    {
        Debug.Log("ConcreteVisitor is visiting ConcreteElementA");
        elementA.OperationA();
    }

    public void VisitElementB(ConcreteElementB elementB)
    {
        Debug.Log("ConcreteVisitor is visiting ConcreteElementB");
        elementB.OperationB();
    }
}

// Client class
public class VisitorExample : MonoBehaviour
{
    void Start()
    {
        // Create elements
        ConcreteElementA elementA = new ConcreteElementA();
        ConcreteElementB elementB = new ConcreteElementB();

        // Create visitor
        ConcreteVisitor visitor = new ConcreteVisitor();

        // Accept visitor
        elementA.Accept(visitor);
        elementB.Accept(visitor);
    }
}
