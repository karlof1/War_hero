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
        //prefab granat�w musi mie� rigidbody z wy��czonym usegravity
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(throwPoint.forward * throwForce, ForceMode.VelocityChange);
        rb.useGravity = true;
        //obs�u�y� metod� explode po odczekaniu op�nienia w coroutine
    }
}