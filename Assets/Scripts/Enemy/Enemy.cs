using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    private EnemyData enemyData;
    private void Start()
    {
        enemyData = gameObject.GetComponent<EnemyData>();
    }

    public Enemy()
    {
        healthPoints = enemyData.healthPoints;
        dodgeChance = enemyData.dodgeChance;
        accuracy = enemyData.accuracy;
        attack = 10.0f; // placeholder - explained in parent class
    }

    public override void Attack(Character character)
    {
        character.GetDamage(attack);
    }

    public override void GetDamage(float dmgPoints)
    {
        healthPoints -= dmgPoints;
    }
}
