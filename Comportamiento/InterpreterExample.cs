using UnityEngine;

// Clase de contexto
class Context
{
    public int GetVariableValue(string variableName)
    {
        // Aquí puedes implementar la lógica para obtener el valor de una variable.
        // Por simplicidad, este ejemplo simplemente retorna un valor fijo.
        if (variableName == "x")
            return 5;

        return 0;
    }
}

// Interfaz de expresión
interface IExpression
{
    int Interpret(Context context);
}

// Expresión terminal para variables
class VariableExpression : IExpression
{
    private string variableName;

    public VariableExpression(string variableName)
    {
        this.variableName = variableName;
    }

    public int Interpret(Context context)
    {
        return context.GetVariableValue(variableName);
    }
}

// Expresión no terminal para suma
class SumExpression : IExpression
{
    private IExpression leftExpression;
    private IExpression rightExpression;

    public SumExpression(IExpression leftExpression, IExpression rightExpression)
    {
        this.leftExpression = leftExpression;
        this.rightExpression = rightExpression;
    }

    public int Interpret(Context context)
    {
        return leftExpression.Interpret(context) + rightExpression.Interpret(context);
    }
}

// Clase de ejemplo
public class InterpreterExample : MonoBehaviour
{
    void Start()
    {
        // Crear el contexto
        Context context = new Context();

        // Crear la expresión: x + 10
        IExpression expression = new SumExpression(new VariableExpression("x"), new VariableExpression("x"));

        // Evaluar la expresión
        int result = expression.Interpret(context);
        Debug.Log("Resultado: " + result);
    }
}
