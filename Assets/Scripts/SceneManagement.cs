using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class SceneManagement : MonoBehaviour
{
    private InputController inputController;

    private Vector3 previousLocation;

    void Start()
    {
        inputController = GameObject.Find("Player").GetComponent<InputController>();
        //inputController.OnRoomEntered += LoadScene;
        SceneManager.sceneLoaded += OnSceneChanged;
    }

    private void LoadScene(string sceneName)
    {
        previousLocation = GameObject.Find("Player").GetComponent<Transform>().position;
        Debug.Log(previousLocation);
        if (SceneManager.GetSceneByName(sceneName) != null)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }
        else
        {
            Debug.LogWarning("There's no such scene");
        }
    }

    private void OnSceneChanged(Scene scene, LoadSceneMode mode)
    {
        
        GameObject spawnPoint = GameObject.Find("SpawnPoint");

        if (spawnPoint != null && scene.isLoaded)
        {
            Debug.Log("Jestem w scenie: " + scene.name);
            GameObject player = GameObject.Find("Player");
            //Destroy(player);
            NavMeshAgent navMesh = player.GetComponent<NavMeshAgent>();

            navMesh.enabled = false;
            if(scene.name == "MainScene")
            {
                player.transform.SetPositionAndRotation(previousLocation, Quaternion.identity);
            }
            else
            {
                player.transform.SetPositionAndRotation(spawnPoint.transform.position, Quaternion.identity);
            }
            
            //Debug.Break();
            navMesh.enabled = true;
        }
    }
}
