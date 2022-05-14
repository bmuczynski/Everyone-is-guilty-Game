using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocationHandler : MonoBehaviour
{
    [SerializeField]
    private Scene room;

    public Scene GetRoom()
    {
        return this.room;
    }

    
}
