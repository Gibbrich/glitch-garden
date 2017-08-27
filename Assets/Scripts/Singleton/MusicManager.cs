using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : Singleton<MusicManager>
{
    public AudioClip[] LevelMusicChangeArray;

    private AudioSource audioSource;

    protected void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        audioSource = GetComponent<AudioSource>();
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AudioClip clip = LevelMusicChangeArray[scene.buildIndex];
        if (clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();           
        }
    }
}