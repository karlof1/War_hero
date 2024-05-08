using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SmokeGrenade : ThrowableWeapon
{
    private GameObject grenade;
    public override void Use()
    {
        base.Use();

        grenade = Instantiate(grenadePrefab, throwPoint.position, throwPoint.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(throwPoint.forward * throwForce, ForceMode.VelocityChange);
        rb.useGravity = true;

        WeaponController.fragGrenadeAvailable = false;

        Invoke("Explode", explosionDelay);
    }

    public override void Explode()
    {
        base.Explode();

        GameObject explosionEffect = Instantiate(explosionPrefab, grenade.transform.position + explosionOffset, grenade.transform.rotation);
    }
}