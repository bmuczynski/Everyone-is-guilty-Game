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
    private NavMeshAgent agent;
    private float moveDelay = 0.5f;

    [SerializeField]
    private GameObject movementMarker;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        
        agent = GetComponent<NavMeshAgent>();

        GetComponent<InputController>().OnGroundMovement += Move;
        //rajec
        GetComponent<MainCharacter>().Dead += PlayDead;
        //rajec
    }
    // animator state change
    void PlayDead()
    {
        animator.SetBool("IsDead", true);
    }

    private void Update()
    {
        StopPlayer();
    }

    public void Move(RaycastHit hit)
    {
        StartCoroutine(WaitForMove(hit));
    }

    private void StopPlayer()
    {
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    animator.SetBool("isMoving", false);
                }
            }
        }
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

    private IEnumerator WaitForMove(RaycastHit hit)
    {
            DestroyAllGO("Marker");
            
            GameObject go = Instantiate(movementMarker,
                hit.point + new Vector3(0, 2, 0),
                Quaternion.identity);

            yield return new WaitForSeconds(moveDelay);

            animator.SetBool("isMoving", true);
            agent.SetDestination(hit.point);
    }
}
