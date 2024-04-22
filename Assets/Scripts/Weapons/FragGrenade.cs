using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FragGrenade : ThrowableWeapon
{

    public override void Use()
    {
        base.Use();

        GameObject grenade = Instantiate(grenadePrefab, throwPoint.position, throwPoint.rotation);
        //prefab granatów musi mieæ rigidbody z wy³¹czonym usegravity
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(throwPoint.forward * throwForce, ForceMode.VelocityChange);
        rb.useGravity = true;

        WeaponController.fragGrenadeAvailable = false;
        //obs³u¿yæ metodê explode po odczekaniu opóŸnienia w coroutine
    }
}