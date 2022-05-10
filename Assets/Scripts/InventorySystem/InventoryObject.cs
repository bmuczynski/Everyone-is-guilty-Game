using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New inventory", menuName ="Inventory System/new inventory")]
public class InventoryObject : ScriptableObject
{

    public List<InventorySlot> Container = new List<InventorySlot>();
    public void AddItem(ItemObject _item)
    {
        bool hasItem = false;
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item == _item)
            {
                hasItem = true;
                break;
            }
        }
        if (!hasItem)
        {
            Container.Add(new InventorySlot(_item));
        }
    }

    public class InventorySlot
    {
        public ItemObject item;
        public InventorySlot(ItemObject _item)
        {
            item = _item;
        }


    }
}