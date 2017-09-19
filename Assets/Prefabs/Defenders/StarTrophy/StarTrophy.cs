using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarTrophy : Defender
{
    private StarDisplay starDisplay;
    
    protected override void Start()
    {
        base.Start();
        
        starDisplay = FindObjectOfType<StarDisplay>();
    }
    
    // called by animation event
    private void AddStars(int amount)
    {
        starDisplay.AddStars(amount);
    }
}