using System.Collections;
using System.Collections.Generic;
using Combat_System.Weapon;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    protected Weapon _primaryWeapon;
    protected Weapon _secondaryWeapon;

    public void Attack(AttackType attackType)
    {
        
    }
}

public enum AttackType
{
    Primary = 0,
    Secondary = 1,
}
