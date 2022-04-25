using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public float healthPoints { get; set; }
    public float attack { get; set; } // must be replaced with weapon's damage
    public float dodgeChance { get; set; }
    public float accuracy { get; set; }

    public float maxHealthPoints { get; set; }
    public abstract void Attack(Character character);
    public abstract void GetDamage(float dmgPoints);
    public bool CheckIfDied()
    {
        if (this.healthPoints <= 0) return true;
        else return false;
    }

    public void Die()
    {
        GameObject.Destroy(gameObject);
    }
}
