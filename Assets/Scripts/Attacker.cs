using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Attacker : MonoBehaviour
{
    [Range(0, 5f)]
    public float WalkSpeed;
    
    // Use this for initialization
    void Start()
    {
        if (GetComponent<Rigidbody2D>() == null)
        {
            Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.simulated = true;
            rb.useFullKinematicContacts = true;
            rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * WalkSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals(Tags.PROJECTILE))
        {
            print(gameObject.name + " was hit by a projectile");
        }
        else if (other.tag.Equals(Tags.DEFENDER))
        {
            print(gameObject.name + " faced defender");
            Attack();
        }
    }

    private void Attack()
    {
        
    }
}