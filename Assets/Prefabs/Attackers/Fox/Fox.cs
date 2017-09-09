using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Fox : MonoBehaviour
{
    private const string JUMP_TRIGGER = "JumpTrigger";

    public float Damage = 3;
    
    private Animator animator;
    private Attacker attacker;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Defender defender = other.GetComponent<Defender>();
        if (defender)
        {
            if (other.GetComponent<Gravestone>())
            {
                animator.SetTrigger(JUMP_TRIGGER);
            }
            else
            {
                attacker.Attack(defender);
            }
        }
    }
}