using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MainCharacter : Character
{
    public event Action<float> onHealthChanged;
    public PlayerData playerData;

    public event Action Dead; //->MovementController "Animacje"

    public int experiencePoints;
    public int characterLevel;

    private void Awake()
    {
        healthPoints = playerData.healthPoints;
        maxHealthPoints = healthPoints;
        dodgeChance = playerData.dodgeChance;
        accuracy = playerData.accuracy;
        attack = 10.0f;
        experiencePoints = 0;
        characterLevel = 1;

        Debug.Log("HP: " + maxHealthPoints + " \nDodge: " + dodgeChance);
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
            Dead?.Invoke();
        }
        // here handle all the stuff that's happening on getting hit
    }
    
}
