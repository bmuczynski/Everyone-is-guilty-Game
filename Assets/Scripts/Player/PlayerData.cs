using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player data", menuName = "Data/Player Data")]
public class PlayerData : ScriptableObject
{
    [Header("Player Parameters")]

    public string className;

    [Space(20)]

    [Range(0, 100)]
    public float healthPoints;

    [Range(0, 100)]
    public float dodgeChance;

    [Range(0, 100)]
    public float accuracy;

    [Range(0, 10)]
    public int attackRange;

}
