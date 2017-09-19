using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Attacker : Unit
{
    [Range(0, 5f)]
    public float Speed;
    [Tooltip("Average number of seconds between appearances")]
    public float SeenEverySeconds;

    private Animator animator;
    private Defender currentTarget;
    
    // Use this for initialization
    protected virtual void Start()
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

    // called by Animation event
    private void StrikeCurrentTarget(float damage)
    {
        currentTarget.TakeDamage(damage);
    }

    public void Attack(Defender target)
    {
        currentTarget = target;
        currentTarget.Death += OnCurrentTargetDeath;
        animator.SetBool(IS_ATTACKING, true);
    }

    private void OnCurrentTargetDeath()
    {
        animator.SetBool(IS_ATTACKING, false);
        currentTarget = null;
    }
    
    public void SetSpeed(float speed)
    {
        Speed = speed; 
    }

    private void OnDisable()
    {
        if (currentTarget)
        {
            currentTarget.Death -= OnCurrentTargetDeath;
        }
    }
}