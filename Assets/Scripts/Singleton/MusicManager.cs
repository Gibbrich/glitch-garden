using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : Singleton<MusicManager>
{
    private const string TAG = "MusicManager";
    
    public AudioClip[] LevelMusicChangeArray;

    private AudioSource audioSource;
    private AudioClip currentPlaying;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsManager.MasterVolume;
    }

    public void PlaySceneMusic(int sceneIndex, bool isLooping)
    {
        if (LevelMusicChangeArray.Length <= sceneIndex || LevelMusicChangeArray[sceneIndex] == null)
        {
            Utils.print(TAG, "Music for this level is not set");
        }
        else
        {
            AudioClip clip = LevelMusicChangeArray[sceneIndex];
            if (clip != null && currentPlaying != clip)
            {
                audioSource.clip = clip;
                audioSource.loop = isLooping;
                currentPlaying = clip;
                audioSource.Play();           
            }
        }
    }

    public void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
    }
}