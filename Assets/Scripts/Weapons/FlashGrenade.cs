using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlashGrenade : ThrowableWeapon
{
    public override void Use()
    {
        base.Use();

        GameObject grenade = Instantiate(grenadePrefab, throwPoint.position, throwPoint.rotation);
        //prefab granatów musi mieæ rigidbody z wy³¹czonym usegravity
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(throwPoint.forward * throwForce, ForceMode.VelocityChange);
        rb.useGravity = true;
        //obs³u¿yæ metodê explode po odczekaniu opóŸnienia w coroutine
    }
}