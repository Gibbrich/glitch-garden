using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public GameObject PausePanel;
    
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PauseGame()
    {
        // todo stop defenders firing, projectile moving, attackers (moving, spawning, attacking and animating), disable clicking on everything except PausePanel
        PausePanel.SetActive(true);
        LevelManager.Instance.PauseGame();
    }
}