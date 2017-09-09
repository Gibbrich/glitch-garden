using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Lizard : MonoBehaviour
{
    public float Damage = 2;
    
    private Attacker attacker;
    
    private void Start()
    {
        attacker = GetComponent<Attacker>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Defender defender = other.GetComponent<Defender>();
        if (defender)
        {
            attacker.Attack(defender);
        }
    }
}