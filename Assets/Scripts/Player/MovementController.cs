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

    private GameObject go;

    private Camera camera;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        
        agent = GetComponent<NavMeshAgent>();

        camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();

        Debug.Log(agent.obstacleAvoidanceType);
        agent.obstacleAvoidanceType = ObstacleAvoidanceType.GoodQualityObstacleAvoidance;

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

        InstantiateMarker(hit);

        yield return new WaitForSeconds(moveDelay);

        animator.SetBool("isMoving", true);
        agent.SetDestination(hit.point);
    }

    private void InstantiateMarker(RaycastHit hit)
    {
        if(go == null)
        {
            go = Instantiate(movementMarker,
                   hit.point,
                   Quaternion.identity);
        }
        else
        {
            go.transform.position = hit.point;
        }
        go.transform.LookAt(camera.transform.position, Vector3.up);
        go.transform.rotation = Quaternion.LookRotation(Vector3.up, Vector3.up); // make sure that our GO is always facing sky
        
    }
}
