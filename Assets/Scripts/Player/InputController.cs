using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    // events
    public event Action<ItemObject> OnItemPicked;
    public event Action<RaycastHit> OnGroundMovement;
    public event Action OnEnemyClicked;
    public event Action<Dialogue> OnDialogueStarted;
    public event Action<string> OnRoomEntered;

    // Unity New Input System
    private PlayerInputActions playerInput;

    [SerializeField]
    private float interactionDistance;

    void Start()
    {
        playerInput = new PlayerInputActions();
        playerInput.Player.Enable();
        playerInput.Player.Movement.performed += ManageMouseInput;
    }

    private void ManageMouseInput(InputAction.CallbackContext context)
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            GameObject go = hitInfo.collider.gameObject;
            float distance = Vector3.Distance(transform.position, go.transform.position);

            switch(go.tag)
            {
                case "Item":
                    if(distance <= interactionDistance)
                    {
                        ItemObject ob = hitInfo.collider.gameObject.GetComponent<Item>().item;
                        OnItemPicked(ob);
                        DestroyImmediate(go);
                    }
                    break;
                case "Enemy":
                    Debug.Log("Walniêto przeciwnika - ale nie zaimplementowano jeszcze walki ;)");
                    break;
                case "Ground":
                    Debug.Log("Ground hit: " + hitInfo.point.ToString());
                    OnGroundMovement(hitInfo);
                    break;
                case "NPC":
                    if(distance <= interactionDistance)
                    {
                        Dialogue dialogue = hitInfo.collider.gameObject.GetComponent<DialogueHolder>().GetCurrDialogue();
                        if (dialogue != null)
                        {
                            OnDialogueStarted(dialogue);
                        }
                    }
                    break;
                case "Door":
                    if(distance <= interactionDistance)
                    {
                        Debug.Log(go.name);
                        OnRoomEntered(go.GetComponent<LocationHandler>().GetRoomName());
                    }
                    break;
            }
        }
    }
}
