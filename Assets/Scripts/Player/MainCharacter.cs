using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : Character
{
    private PlayerData playerData;

    private void Start()
    {
        playerData = gameObject.GetComponent<PlayerData>(); // getting reference to Data placed on object
    }

    public MainCharacter()
    {
        healthPoints = playerData.healthPoints;
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
        // here handle all the stuff that's happening on getting hit
    }
}
