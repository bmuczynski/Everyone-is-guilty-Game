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

    [SerializeField]
    private LayerMask groundLayer;

    [SerializeField]
    private GameObject movementMarker;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        //rajec
        GetComponent<MainCharacter>().Dead += PlayDead ;
        //rajec
        agent = GetComponent<NavMeshAgent>();

        playerInput = new PlayerInputActions();
        playerInput.Player.Enable();
        playerInput.Player.Movement.performed += Move;
    }
    // animator state change
    void PlayDead()
    {
        animator.SetBool("IsDead", true);
    }

    private void Update() => StopPlayer();

    private void OnDisable() => playerInput.Player.Movement.performed -= Move;

    public void Move(InputAction.CallbackContext context) => StartCoroutine(WaitForMove());
    
    private void StopPlayer()
    {
        if (agent.velocity == Vector3.zero) animator.SetBool("isMoving", false);
    }

    private void DestroyAllGO(string tag)
    {
        GameObject[] markers = GameObject.FindGameObjectsWithTag(tag);

        if(markers.Length > 0)
        {
            foreach (GameObject marker in markers)
            {
                DestroyImmediate(marker);
            }
        }
    }

    private IEnumerator WaitForMove()
    {

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()), out RaycastHit hit))
        {
            DestroyAllGO("Marker");
            GameObject go = Instantiate(movementMarker,
                hit.point,
                Quaternion.identity);

            yield return new WaitForSeconds(moveDelay);
            Debug.Log(hit.point.GetType().Name);
            animator.SetBool("isMoving", true);
            agent.SetDestination(hit.point);
        }
    }
}
