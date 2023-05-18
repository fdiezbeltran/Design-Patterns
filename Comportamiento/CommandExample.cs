using UnityEngine;
using System.Collections.Generic;

// Interfaz del comando
public interface ICommand
{
    void Execute();
    void Undo();
}

// Clase concreta del comando para agregar stock
public class AddStockCommand : ICommand
{
    private StockManager stockManager;
    private int amount;

    public AddStockCommand(StockManager manager, int quantity)
    {
        stockManager = manager;
        amount = quantity;
    }

    public void Execute()
    {
        stockManager.AddStock(amount);
    }

    public void Undo()
    {
        stockManager.RemoveStock(amount);
    }
}

// Clase concreta del comando para restar stock
public class RemoveStockCommand : ICommand
{
    private StockManager stockManager;
    private int amount;

    public RemoveStockCommand(StockManager manager, int quantity)
    {
        stockManager = manager;
        amount = quantity;
    }

    public void Execute()
    {
        stockManager.RemoveStock(amount);
    }

    public void Undo()
    {
        stockManager.AddStock(amount);
    }
}

// Clase que maneja el stock del producto
public class StockManager
{
    private int stock;

    public StockManager()
    {
        stock = 0;
    }

    public void AddStock(int quantity)
    {
        stock += quantity;
        Debug.Log("Stock added: " + quantity + ", Total stock: " + stock);
    }

    public void RemoveStock(int quantity)
    {
        if (stock >= quantity)
        {
            stock -= quantity;
            Debug.Log("Stock removed: " + quantity + ", Total stock: " + stock);
        }
        else
        {
            Debug.Log("Insufficient stock!");
        }
    }
}

// Clase de ejemplo que utiliza el patrón Command
public class CommandExample : MonoBehaviour
{
    private StockManager stockManager;
    private List<ICommand> commandHistory;
    private int currentCommandIndex;

    private void Start()
    {
        stockManager = new StockManager();
        commandHistory = new List<ICommand>();
        currentCommandIndex = -1;

        // Ejemplo de uso del patrón Command
        AddStock(10);
        RemoveStock(5);
        AddStock(3);
        Undo();
        Redo();
    }

    private void AddStock(int quantity)
    {
        ICommand addStockCommand = new AddStockCommand(stockManager, quantity);
        addStockCommand.Execute();

        commandHistory.RemoveRange(currentCommandIndex + 1, commandHistory.Count - currentCommandIndex - 1);
        commandHistory.Add(addStockCommand);
        currentCommandIndex++;
    }

    private void RemoveStock(int quantity)
    {
        ICommand removeStockCommand = new RemoveStockCommand(stockManager, quantity);
        removeStockCommand.Execute();

        commandHistory.RemoveRange(currentCommandIndex + 1, commandHistory.Count - currentCommandIndex - 1);
        commandHistory.Add(removeStockCommand);
        currentCommandIndex++;
    }

    private void Undo()
    {
        if (currentCommandIndex >= 0)
        {
            ICommand currentCommand = commandHistory[currentCommandIndex];
            currentCommand.Undo();
            currentCommandIndex--;
        }
        else
        {
            Debug.Log("No more commands to undo.");
        }
    }

    private void Redo()
    {
        if (currentCommandIndex < commandHistory.Count - 1)
        {
            currentCommandIndex++;
            ICommand currentCommand = commandHistory[currentCommandIndex];
        }
    }
}
