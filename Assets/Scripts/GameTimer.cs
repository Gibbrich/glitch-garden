﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class GameTimer : MonoBehaviour
{
    public float LevelSeconds = 100;
    private Slider slider;
    private bool isEndOfLevel = false;
    public AudioClip victoryClip;
    private GameObject winLabel;
    
    // Use this for initialization
    void Start()
    {
        slider = FindObjectOfType<Slider>();

        FindYouWinLabel();
        winLabel.SetActive(false);
    }

    private void FindYouWinLabel()
    {
        winLabel = GameObject.Find("WinLabel");
        if (!winLabel)
        {
            Debug.LogWarning("Please create WinLabel object");
        }
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = Time.timeSinceLevelLoad / LevelSeconds;

        bool isTimeIsUp = Time.timeSinceLevelLoad >= LevelSeconds;
        if (isTimeIsUp && !isEndOfLevel)
        {
            HandeWinCondition();
        }
    }

    private void HandeWinCondition()
    {
        DestroyAllTaggedObjects();
        winLabel.SetActive(true);
        AudioSource.PlayClipAtPoint(victoryClip, transform.position);
        LevelManager.Instance.LoadNextLevel(victoryClip.length);
        isEndOfLevel = true;
    }

    private void DestroyAllTaggedObjects()
    {
        foreach (GameObject o in GameObject.FindGameObjectsWithTag(Tags.DESTROY_ON_WIN))
        {
            Destroy(o);
        }
    }
}