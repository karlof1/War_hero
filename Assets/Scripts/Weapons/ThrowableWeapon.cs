using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableWeapon : Weapon
{
    public float explosionRadius;
    public float explosionDelay;
    public GameObject grenadePrefab;
    public Transform throwPoint;
    public float throwForce;

    public GameObject explosionPrefab;
    public Vector3 explosionOffset;

    public override void Use()
    {
        base.Use();

        gameObject.SetActive(false);
    }

    public virtual void Explode()
    {

    }
}