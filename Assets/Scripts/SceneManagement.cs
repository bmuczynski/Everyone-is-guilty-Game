using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    private InputController inputController;

    void Start()
    {
        inputController = GameObject.Find("Player").GetComponent<InputController>();
        inputController.OnRoomEntered += LoadScene;
        SceneManager.sceneLoaded += OnSceneChanged;
    }

    private void LoadScene(string sceneName)
    {
        if(SceneManager.GetSceneByName(sceneName) != null)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
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
            GameObject.Find("Player").transform.SetPositionAndRotation(spawnPoint.transform.position, Quaternion.identity);
        }
    }
}
