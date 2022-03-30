using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    private PlayerData playerData;
    private float healthPoints;
    private float dodgeChance;
    private float accuracy;

    void Start()
    {
        healthPoints = playerData.healthPoints;
        dodgeChance = playerData.dodgeChance;
        accuracy = playerData.accuracy;
    }
}
