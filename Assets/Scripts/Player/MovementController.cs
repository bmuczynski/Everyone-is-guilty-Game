using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

// controller for grid movement system (used New Unity Input System)
public class MovementController : MonoBehaviour
{
    private Animator animator;
    private PlayerInputActions playerInput;
    private NavMeshAgent agent;
    private float moveDelay = 0.5f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        playerInput = new PlayerInputActions();
        playerInput.Player.Enable();
        playerInput.Player.Movement.performed += Move;
    }

    private void Update() => StopPlayer();

    private void OnDisable() => playerInput.Player.Movement.performed -= Move;

    private void Move(InputAction.CallbackContext context) => StartCoroutine(WaitForMove());
    
    private void StopPlayer()
    {
        if (agent.velocity == Vector3.zero) animator.SetBool("isMoving", false);
    }

    private IEnumerator WaitForMove()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()), out hit))
        {
            yield return new WaitForSeconds(moveDelay);
            animator.SetBool("isMoving", true);
            agent.SetDestination(hit.point);
        }
    }
}
