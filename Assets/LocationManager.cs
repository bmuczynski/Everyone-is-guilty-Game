using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LocationManager : MonoBehaviour
{
    private Vector3 lastLocation;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Player").GetComponent<InputController>().OnRoomEntered += ChangeLocation;
    }

    private void ChangeLocation(GameObject go)
    {
        GameObject player = GameObject.Find("Player");

        NavMeshAgent navMesh = player.GetComponent<NavMeshAgent>();

        navMesh.enabled = false;

        string locationName = go.GetComponent<LocationHandler>().GetRoomName();

        if (locationName == "LastPlace")
        {
            player.transform.SetPositionAndRotation(lastLocation, Quaternion.identity);
        }
        else
        {
            lastLocation = player.transform.position;
            player.transform.SetPositionAndRotation(GameObject.Find(locationName).transform.position, Quaternion.identity);
        }
        navMesh.enabled = true;
    }
}
