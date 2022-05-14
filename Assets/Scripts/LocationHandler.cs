using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocationHandler : MonoBehaviour
{
    [SerializeField]
    private string locationToGo;

    public string GetRoomName()
    {
        return this.locationToGo;
    }
}
