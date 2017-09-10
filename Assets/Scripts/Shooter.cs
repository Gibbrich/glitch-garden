using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Shooter : MonoBehaviour
{
    public GameObject Projectile;
    public GameObject ProjectileParent;
    public Transform Gun;

    private void Fire()
    {
        GameObject proj = Instantiate(Projectile);
        proj.transform.parent = ProjectileParent.transform;
        proj.transform.position = Gun.position;
    }
}