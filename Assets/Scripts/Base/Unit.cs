using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Health))]
public class Unit : MonoBehaviour
{
    protected const string IS_ATTACKING = "isAttacking";
    
    public event Action Death = () => {};
    
    protected Health health;

    public Health Health
    {
        get { return health; }
    }

    protected virtual void Start()
    {
        health = GetComponent<Health>();
        health.HealthLessOrEqualZero += OnDeath;
    }

    protected virtual void OnDeath()
    {
        Death();
        Destroy(gameObject);
    }
}