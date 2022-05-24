using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : EnemyCharacter
{
    private EnemyData enemyData;

    public override event Action<int> OnDeadGiveExp;

    private void Start()
    {
        enemyData = gameObject.GetComponent<EnemyData>();
    }

    public Enemy()
    {
        healthPoints = enemyData.healthPoints;
        dodgeChance = enemyData.dodgeChance;
        accuracy = enemyData.accuracy;
        experienceValue = enemyData.experienceValue;
        attack = 10.0f;
    }

    public override void Attack(Character character)
    {
        character.GetDamage(attack);
    }

    public override void GetDamage(float dmgPoints)
    {
        healthPoints -= dmgPoints;
        if(CheckIfDied())
        {
            OnDeadGiveExp(experienceValue);
            Die();
        }
    }
}
