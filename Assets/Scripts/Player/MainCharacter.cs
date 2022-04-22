using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MainCharacter : Character
{
    public event Action<float> onHealthChanged;
    private PlayerData playerData;

    private void Start()
    {
        playerData = gameObject.GetComponent<PlayerData>(); // getting reference to Data placed on object
    }

    public MainCharacter()
    {
        healthPoints = playerData.healthPoints;
        maxHealthPoints = healthPoints;
        dodgeChance = playerData.dodgeChance;
        accuracy = playerData.accuracy;
        attack = 10.0f; // placeholder - explained in parent class
    }

    public override void Attack(Character character)
    {
        character.GetDamage(this.attack);
        // implement some animations or audio effects ? 
    }

    public override void GetDamage(float dmgPoints)
    {
        healthPoints -= dmgPoints;
        onHealthChanged(healthPoints);
        if(CheckIfDied())
        {
            Die();
        }
        // here handle all the stuff that's happening on getting hit
    }
}
