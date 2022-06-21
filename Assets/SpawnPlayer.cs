using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        GameObject go = Instantiate(player);
        go.transform.position = new Vector3(37, 1.043f, 40.73f);
    }

}
