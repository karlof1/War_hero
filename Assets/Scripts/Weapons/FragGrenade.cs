using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FragGrenade : ThrowableWeapon
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
        DealDamage();
    }

    public void DealDamage()
    {
        EnemyController enemyController = FindObjectOfType<EnemyController>();
        PlayerHealthBar playerHealthBar = FindObjectOfType<PlayerHealthBar>();

        foreach (var enemy in enemyController.spawnedEnemies)
        {
            if(Vector3.Distance(grenade.transform.position, enemy.transform.position) <= explosionRadius)
            {
                enemy.healthBar.SubtractHealth(attackDamage);
            }
        }

        if (Vector3.Distance(grenade.transform.position, transform.position) <= explosionRadius)
        {
            playerHealthBar.SubtractHealth(attackDamage);
        }
    }
}