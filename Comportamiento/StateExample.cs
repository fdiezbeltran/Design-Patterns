using UnityEngine;

// Interfaz que define los métodos comunes para todos los estados
public interface IEnemyState
{
    void Enter();
    void Update();
    void Exit();
}

// Implementación del estado Patrol
public class PatrolState : IEnemyState
{
    public void Enter()
    {
        Debug.Log("Entering Patrol State");
    }

    public void Update()
    {
        Debug.Log("Patrolling...");
    }

    public void Exit()
    {
        Debug.Log("Exiting Patrol State");
    }
}

// Implementación del estado Chase
public class ChaseState : IEnemyState
{
    public void Enter()
    {
        Debug.Log("Entering Chase State");
    }

    public void Update()
    {
        Debug.Log("Chasing...");
    }

    public void Exit()
    {
        Debug.Log("Exiting Chase State");
    }
}

// Implementación del estado Stand
public class StandState : IEnemyState
{
    public void Enter()
    {
        Debug.Log("Entering Stand State");
    }

    public void Update()
    {
        Debug.Log("Standing...");
    }

    public void Exit()
    {
        Debug.Log("Exiting Stand State");
    }
}

// Clase principal que utiliza el patrón State
public class StateExample : MonoBehaviour
{
    private IEnemyState currentState;

    // Enumeración para definir los diferentes estados del enemigo
    private enum EnemyState
    {
        Patrol,
        Chase,
        Stand
    }

    [SerializeField] private EnemyState initialEnemyState; // Estado inicial seleccionado desde el inspector
    private EnemyState currentEnemyState;

    private void Start()
    {
        // Inicializar el estado actual con el estado inicial seleccionado
        currentEnemyState = initialEnemyState;
        SwitchState(currentEnemyState);
    }

    private void Update()
    {
        // Actualizar el estado actual
        currentState.Update();

        // Cambiar de estado si es necesario
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Cambiar al siguiente estado
            EnemyState nextState = (EnemyState)(((int)currentEnemyState + 1) % 3);
            currentEnemyState = nextState;
            SwitchState(currentEnemyState);
        }
    }

    private void SwitchState(EnemyState newState)
    {
        // Salir del estado actual
        if (currentState != null)
        {
            currentState.Exit();
        }

        // Cambiar al nuevo estado
        switch (newState)
        {
            case EnemyState.Patrol:
                currentState = new PatrolState();
                break;
            case EnemyState.Chase:
                currentState = new ChaseState();
                break;
            case EnemyState.Stand:
                currentState = new StandState();
                break;
        }

        // Entrar al nuevo estado
        currentState.Enter();
    }
}
