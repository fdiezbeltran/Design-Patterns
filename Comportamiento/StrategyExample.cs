using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon
{
    public abstract void Attack();
}

public class Sword : Weapon
{
    public override void Attack()
    {
        Debug.Log("Ataque con espada");
    }
}

public class Axe : Weapon
{
    public override void Attack()
    {
        Debug.Log("Ataque con hacha");
    }
}

public class Bow : Weapon
{
    public override void Attack()
    {
        Debug.Log("Ataque con arco");
    }
}

public class StrategyExample : MonoBehaviour
{
    public enum WeaponType
    {
        Sword,
        Axe,
        Bow
    }

    public WeaponType selectedWeapon;
    private Weapon weapon;

    private void Start()
    {
        // Crea la instancia del arma basada en el enum seleccionado
        switch (selectedWeapon)
        {
            case WeaponType.Sword:
                weapon = new Sword();
                break;
            case WeaponType.Axe:
                weapon = new Axe();
                break;
            case WeaponType.Bow:
                weapon = new Bow();
                break;
        }

        // Verifica si se ha seleccionado un arma y la utiliza
        if (weapon != null)
        {
            weapon.Attack();
        }
    }
}

