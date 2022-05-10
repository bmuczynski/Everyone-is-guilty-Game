using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public InventoryObject inventory;

    public event UnityAction<ItemObject> ItemPicked;

    public void AddItemToInventory(ItemObject item)
    {

            inventory.AddItem(item);
            ItemPicked?.Invoke(item);
            Debug.Log("Item Added");
    }
}
