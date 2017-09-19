using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Speed = 1f;
    public float Damage = 1f;

    private void Update()
    {
        transform.Translate(Vector3.right * Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Attacker attacker = other.GetComponent<Attacker>();
        if (attacker)
        {
            attacker.TakeDamage(Damage);
            Destroy(gameObject);
        }
    }
}