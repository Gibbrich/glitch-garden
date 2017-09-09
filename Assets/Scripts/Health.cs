using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action HealthLessOrEqualZero = () => {};
    
    [SerializeField] 
    private float value = 10;

    public float Value
    {
        get { return value; }
        set
        {
            this.value = value;
            if (this.value <= 0)
            {
                HealthLessOrEqualZero();
            }
        }
    }
}