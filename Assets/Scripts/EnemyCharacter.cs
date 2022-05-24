using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class EnemyCharacter : Character
{

    public abstract event Action<int> OnDeadGiveExp;
    public int experienceValue;
}
