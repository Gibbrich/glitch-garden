using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Unit : MonoBehaviour
{
    protected const string IS_ATTACKING = "isAttacking";
    
    public event Action Death = () => {};
    
    [SerializeField]
    protected float health = 100;
    
    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Death();
            Destroy(gameObject);
        }
    }
}