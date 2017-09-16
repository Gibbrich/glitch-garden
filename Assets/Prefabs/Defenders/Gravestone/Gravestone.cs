using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Gravestone : MonoBehaviour
{
    private const string UNDER_ATTACK_TRIGGER = "underAttackTrigger";
    private Animator animator;

    private void Start()
    {
        animator = FindObjectOfType<Animator>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<Attacker>())
        {
            animator.SetTrigger(UNDER_ATTACK_TRIGGER);
        }
    }
}