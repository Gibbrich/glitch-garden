using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : Unit
{
    [SerializeField]
    private int starCost = 100;
        
    protected virtual void Start()
    {
        Utils.FindOrCreateParent(gameObject, "Defenders");
    }

    public int GetStarCost()
    {
        return starCost;
    }
}