using UnityEngine;
using System.Collections.Generic;

// Interfaz del mediador
public interface IChatMediator
{
    void AddUser(IUser user);
    void SendMessage(string message, IUser sender);
}

// Interfaz del usuario
public interface IUser
{
    void SendMessage(string message);
    void ReceiveMessage(string message);
}

// Implementación del mediador
public class ChatMediator : IChatMediator
{
    private List<IUser> users;

    public ChatMediator()
    {
        users = new List<IUser>();
    }

    public void AddUser(IUser user)
    {
        users.Add(user);
    }

    public void SendMessage(string message, IUser sender)
    {
        foreach (var user in users)
        {
            if (user != sender)
                user.ReceiveMessage(message);
        }
    }
}

// Implementación de usuario
public class ChatUser : IUser
{
    private string name;
    private IChatMediator chatMediator;

    public ChatUser(string name, IChatMediator chatMediator)
    {
        this.name = name;
        this.chatMediator = chatMediator;
        chatMediator.AddUser(this);
    }

    public void SendMessage(string message)
    {
        Debug.Log(name + " envió un mensaje: " + message);
        chatMediator.SendMessage(message, this);
    }

    public void ReceiveMessage(string message)
    {
        Debug.Log(name + " recibió un mensaje: " + message);
    }
}

// Clase de ejemplo de uso
public class MediatorExample : MonoBehaviour
{
    private void Start()
    {
        // Crear el mediador
        IChatMediator chatMediator = new ChatMediator();

        // Crear usuarios
        IUser user1 = new ChatUser("Usuario1", chatMediator);
        IUser user2 = new ChatUser("Usuario2", chatMediator);
        IUser user3 = new ChatUser("Usuario3", chatMediator);

        // Enviar mensajes
        user1.SendMessage("¡Hola a todos!");
        user2.SendMessage("¿Cómo están?");
    }
}
