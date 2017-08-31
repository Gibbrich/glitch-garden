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
        VolumeSlider.value = PlayerPrefsManager.MasterVolume;
        DifficultySlider.value = PlayerPrefsManager.Difficulty;
        
        VolumeSlider.GetComponent<Slider>().onValueChanged.AddListener(MusicManager.Instance.ChangeVolume);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SaveAndExit()
    {
        PlayerPrefsManager.MasterVolume = VolumeSlider.value;
        PlayerPrefsManager.Difficulty = DifficultySlider.value;
        
        LevelManager.Instance.LoadLevel(LevelManager.START);
    }

    private void OnDisable()
    {
        if (VolumeSlider)
        {
            VolumeSlider.GetComponent<Slider>().onValueChanged.RemoveListener(MusicManager.Instance.ChangeVolume);            
        }
    }
}