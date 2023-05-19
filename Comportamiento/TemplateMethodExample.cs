using UnityEngine;

public abstract class TemplateMethod : MonoBehaviour
{
    // Método de plantilla
    public void Template()
    {
        Step1();
        Step2();
        Step3();
    }

    protected abstract void Step1();
    protected abstract void Step2();
    protected abstract void Step3();
}

public class ConcreteClassA : TemplateMethod
{
    protected override void Step1()
    {
        Debug.Log("ConcreteClassA - Paso 1");
    }

    protected override void Step2()
    {
        Debug.Log("ConcreteClassA - Paso 2");
    }

    protected override void Step3()
    {
        Debug.Log("ConcreteClassA - Paso 3");
    }
}

public class ConcreteClassB : TemplateMethod
{
    protected override void Step1()
    {
        Debug.Log("ConcreteClassB - Paso 1");
    }

    protected override void Step2()
    {
        Debug.Log("ConcreteClassB - Paso 2");
    }

    protected override void Step3()
    {
        Debug.Log("ConcreteClassB - Paso 3");
    }
}

public enum ExampleType
{
    ClassA,
    ClassB
}

public class TemplateMethodExample : MonoBehaviour
{
    public ExampleType exampleType;

    private TemplateMethod example;

    private void Start()
    {
        switch (exampleType)
        {
            case ExampleType.ClassA:
                example = new ConcreteClassA();
                break;
            case ExampleType.ClassB:
                example = new ConcreteClassB();
                break;
        }

        example.Template();
    }
}
