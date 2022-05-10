using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New weapon object",menuName ="Inventory System/Items/Weapon")]
public class NewBehaviourScript : ItemObject
{
    public void Awake()
    {
        type = ItemType.Weapon;
    }
}
