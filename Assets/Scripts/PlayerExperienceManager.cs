using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerExperienceManager : MonoBehaviour
{
    // event to open the level up window 
    public event Action OnLeveledUp;

    // reference to the stats of the character
    private MainCharacter character;
    private EnemyCharacter enemyChar;

    void Start()
    {
        character = GetComponent<MainCharacter>();
        //enemyChar.OnDeadGiveExp += AddExperiencePoints;
    }

    private void AddExperiencePoints(int experiencePoints)
    {
        character.experiencePoints += experiencePoints;
        LevelUp();
    }
    
    private void LevelUp()
    {
        if(character.experiencePoints >= character.characterLevel * 1000)
        {
            character.characterLevel++;
            OnLeveledUp?.Invoke();
        }
    }
}
