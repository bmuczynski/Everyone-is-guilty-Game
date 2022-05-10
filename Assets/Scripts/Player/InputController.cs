using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{

    public event Action<ItemObject> OnItemPicked;
    public event Action OnGroundMovement;
    public event Action OnEnemyClicked;

    private PlayerInputActions playerInput;


    void Start()
    {
        playerInput = new PlayerInputActions();
        playerInput.Player.Enable();
        playerInput.Player.Movement.performed += ManageMouseInput;
    }

    private void ManageMouseInput(InputAction.CallbackContext context)
    {
        RaycastHit hitInfo;
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        
        if (Physics.Raycast(ray, out hitInfo))
        {
            GameObject go = hitInfo.collider.gameObject;

            switch(go.tag)
            {
                case "Item":
                    ItemObject ob = hitInfo.collider.gameObject.GetComponent<Item>().item;
                    OnItemPicked(ob);
                    DestroyImmediate(go);
                    break;
                case "Enemy":
                    Debug.Log("Walnieto przeciwnika");
                    break;
                default:
                    //OnGroundMovement();
                    break;

            }
        }
    }
}
