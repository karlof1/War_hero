using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Molotov : ThrowableWeapon
{
    private GameObject grenade;
    public override void Use()
    {
        base.Use();

        grenade = Instantiate(grenadePrefab, throwPoint.position, throwPoint.rotation);
        //prefab granatów musi mieæ rigidbody z wy³¹czonym usegravity
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(throwPoint.forward * throwForce, ForceMode.VelocityChange);
        rb.useGravity = true;

        WeaponController.molotovAvailable = false;

        Invoke("Explode", explosionDelay);
    }

    public override void Explode()
    {
        base.Explode();

        GameObject explosionEffect = Instantiate(explosionPrefab, grenade.transform.position + explosionOffset, Quaternion.identity);
    }
}