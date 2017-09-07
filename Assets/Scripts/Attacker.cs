using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Attacker : MonoBehaviour
{
    private const string IS_ATTACKING_PARAMETER = "isAttacking";
    
    [Range(0, 5f)]
    public float Speed;

    private Animator animator;
    
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        
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
        transform.Translate(Vector3.left * Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals(Tags.PROJECTILE))
        {
            print(gameObject.name + " was hit by a projectile");
        }
        else if (other.tag.Equals(Tags.DEFENDER))
        {
            SetAttacking(1);
        }
    }

    private void StrikeCurrentTarget(float damage)
    {
        print(gameObject.name + " attacked defender by " + damage);
    }

    public void SetAttacking(float damage)
    {
        animator.SetBool(IS_ATTACKING_PARAMETER, damage > 0);
        if (damage > 0)
        {
            StrikeCurrentTarget(damage);
        }
    }
    
    public void SetSpeed(float speed)
    {
        Speed = speed; 
    }
    
}