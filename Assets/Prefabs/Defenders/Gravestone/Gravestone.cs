using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Gravestone : Defender
{
    private const string UNDER_ATTACK_TRIGGER = "underAttackTrigger";
    private Animator animator;

    protected override void Start()
    {
        base.Start();
        
        animator = FindObjectOfType<Animator>();
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        
        animator.SetTrigger(UNDER_ATTACK_TRIGGER);
    }
}