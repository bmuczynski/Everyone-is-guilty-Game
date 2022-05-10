using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject Layout;
    public GameObject InventorySlotPrefab;

    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().ItemPicked += UI_ItemPicked;


    }

    private void UI_ItemPicked(ItemObject arg0)
    {
        Debug.Log("Ok");
       GameObject newInventorySlot= GameObject.Instantiate(InventorySlotPrefab, Layout.transform);
        Image inventorySlotImage = newInventorySlot.GetComponent<Image>();
        inventorySlotImage.sprite = arg0.imageSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
