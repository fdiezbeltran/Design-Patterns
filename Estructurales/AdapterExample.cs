using UnityEngine;

// Interfaz del nuevo sistema de Unity para los enemigos
public interface IEnemy
{
    void Attack();
    void Defend();
}

// Clase que representa un enemigo en el sistema heredado
public class LegacyEnemy
{
    public void Fire()
    {
        Debug.Log("LegacyEnemy is firing!");
    }

    public void Shield()
    {
        Debug.Log("LegacyEnemy is using shield!");
    }
}

// Adaptador que permite que el LegacyEnemy funcione como un IEnemy
public class EnemyAdapter : MonoBehaviour, IEnemy
{
    private LegacyEnemy legacyEnemy;

    void Awake()
    {
        legacyEnemy = new LegacyEnemy();
    }

    public void Attack()
    {
        legacyEnemy.Fire();
    }

    public void Defend()
    {
        legacyEnemy.Shield();
    }
}

// Clase de ejemplo que utiliza el adaptador
public class AdapterExample : MonoBehaviour
{
    private void Start()
    {
        // Crear un GameObject y adjuntarle el adaptador
        GameObject enemyObject = new GameObject("Enemy");
        EnemyAdapter adapter = enemyObject.AddComponent<EnemyAdapter>();

        // Utilizar el adaptador como un IEnemy
        adapter.Attack();
        adapter.Defend();
    }
}
