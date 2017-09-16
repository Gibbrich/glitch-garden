using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : Unit
{
    public int StarCost = 100;
    
    private GameObject defenderParent;
    private StarDisplay starDisplay;
    
    protected override void Start()
    {
        base.Start();

        defenderParent = GameObject.Find("Defenders");
        if (!defenderParent)
        {
            defenderParent = new GameObject("Defenders");
        }
        gameObject.transform.parent = defenderParent.transform;

        starDisplay = FindObjectOfType<StarDisplay>();
    }

    public void AddStars(int amount)
    {
        starDisplay.AddStars(amount);
    }
}