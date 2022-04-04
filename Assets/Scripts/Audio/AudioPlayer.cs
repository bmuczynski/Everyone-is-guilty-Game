using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] audioClips;
    private AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        SceneManager.sceneLoaded += OnSceneLoaded;
        PlayTheme(SceneManager.GetActiveScene());
    }

    private void OnDisable()
    {
        // unsubscribe event
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayTheme(scene);
    }

    private void PlayTheme(Scene scene)
    {
        if (scene.name == "ProtasScene")
        {
            Debug.Log("I'm in ProtasScene");
            // play main menu theme
            audioSource.clip = audioClips[0];
            audioSource.Play();
        }
        if (scene.name == "GameWindow")
        {
            // play game ambience
            audioSource.clip = audioClips[1];
            audioSource.Play();
        }
    }

    // function to get event from thing and play special sound
    public void PlaySound(GameObject go)
    {
        switch (go.tag)
        {
            case "Player":
                // play sound for player
                break;
            case "Enemy":
                // play sound for enemy
                break;
        }
    }
}
