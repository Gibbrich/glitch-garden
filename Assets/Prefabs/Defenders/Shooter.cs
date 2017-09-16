using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Shooter : MonoBehaviour
{
    private const string IS_ATTACKING = "isAttacking";
    
    public GameObject Projectile;
    public Transform Gun;
    
    private GameObject projectileParent;
    private Animator animator;
    private AttackerSpawner thisLaneSpawner;

    private void Start()
    {
        projectileParent = GameObject.Find("Projectiles");
        if (!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }

        animator = GetComponent<Animator>();
        
        // search for the AttackerSpawner, which is placed on the same lane
        foreach (AttackerSpawner spawner in FindObjectsOfType<AttackerSpawner>())
        {
            if (Math.Abs(spawner.transform.position.y - transform.position.y) < 0.01)
            {
                thisLaneSpawner = spawner;
                break;
            }
            Debug.LogError(name + " can't find AttackerSpawner in lane");
        }
    }

    private void Update()
    {
        animator.SetBool(IS_ATTACKING, IsAttackerAheadInLane());
    }

    private bool IsAttackerAheadInLane()
    {
        if (thisLaneSpawner.transform.childCount == 0)
        {
            return false;
        }

        foreach (Transform child in thisLaneSpawner.transform)
        {
            if (child.position.x > transform.position.x)
            {
                return true;
            }
        }
        return false;
    }

    // called by animation event
    private void Fire()
    {
        GameObject proj = Instantiate(Projectile);
        proj.transform.parent = projectileParent.transform;
        proj.transform.position = Gun.position;
    }
}