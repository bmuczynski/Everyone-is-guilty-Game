using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy data", menuName = "Data/Enemy Data")]
public class EnemyData : ScriptableObject
{
    [Header("Enemy Parameters")]

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

    [Range(0, 1000)]
    public int experienceValue;
}
