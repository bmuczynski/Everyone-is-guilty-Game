using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SoundType
{
    MOVEMENT,
    UI
}

public class AudioPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] audioClips;
    private AudioSource audioSource;
    public AudioSource soundEffectSource;

    private float basicVolume;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // subscribe event
        SceneManager.sceneLoaded += OnSceneLoaded;
        if(audioClips != null) PlayTheme(SceneManager.GetActiveScene());
        GameObject.Find("DialogueManager").GetComponent<DialogueManager>().ChangeMusicVolume += SetMusicVolume;
        GameObject.Find("Player").GetComponent<InputController>().OnSoundTypeEntered += PlaySound;
        basicVolume = audioSource.volume;
    }

    private void OnDisable()
    {
        // unsubscribe event
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (audioClips != null) PlayTheme(scene);
    }

    private void PlayTheme(Scene scene)
    {
        if (scene.name == "MainScene" && audioClips.Length != 0)
        {
            // play game ambience theme
            audioSource.clip = audioClips[0];
            audioSource.Play();
        }
        if (scene.name == "GameWindow" && audioClips.Length != 0)
        {
            audioSource.clip = audioClips[1];
            audioSource.Play();
        }
    }

    // function to get event from thing and play special sound
    public void PlaySound(SoundType type)
    {
        switch (type)
        {
            case SoundType.MOVEMENT:
                Debug.Log("Gram dzwiek chodzenia");
                soundEffectSource.PlayOneShot(audioClips[2]);
                // play sound for click on ground
                break;
            case SoundType.UI:
                soundEffectSource.PlayOneShot(audioClips[3]);
                // play sound button click
                break;
        }
    }

    private void SetMusicVolume(bool isOnDialogue)
    {
        float volumePercent = 0.1f;
        if(isOnDialogue)
        {
            this.audioSource.volume = volumePercent;
        }
        else
        {
            this.audioSource.volume = basicVolume;
        }
    }
}
