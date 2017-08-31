using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    public Slider VolumeSlider;
    public Slider DifficultySlider;
    
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SaveAndExit()
    {
        PlayerPrefsManager.MasterVolume = VolumeSlider.value;
        PlayerPrefsManager.Difficulty = DifficultySlider.value;
        
        LevelManager.Instance.LoadLevel("");
    }
}