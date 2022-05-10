using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemObject item;
    private GameObject Player;
    PlayerInventory playerComponent;
    float Distance;


    int Range=30;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerComponent =Player.GetComponent<PlayerInventory>();
        
    }

    private void OnMouseDown()
    {
        Debug.Log("Click");
        Distance = Vector3.Distance(Player.transform.position,gameObject.transform.position);
        Debug.Log(Distance);
        if (Distance<=Range)
        {
            playerComponent.AddItemToInventory(item);
            Destroy(gameObject);
        }
    }
}

