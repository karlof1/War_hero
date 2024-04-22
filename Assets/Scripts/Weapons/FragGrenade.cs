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
        //prefab granat�w musi mie� rigidbody z wy��czonym usegravity
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(throwPoint.forward * throwForce, ForceMode.VelocityChange);
        rb.useGravity = true;

        WeaponController.fragGrenadeAvailable = false;
        //obs�u�y� metod� explode po odczekaniu op�nienia w coroutine
    }
}