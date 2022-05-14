using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    private InputController inputController;
    // Start is called before the first frame update
    void Start()
    {
        inputController = GameObject.Find("Player").GetComponent<InputController>();
        inputController.OnRoomEntered += LoadScene;
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

}
