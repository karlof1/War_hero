using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeGrenadeItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (WeaponController.smokeGrenadeAvailable == false)
            {
                WeaponController.smokeGrenadeAvailable = true;
                Destroy(gameObject);
            }
        }
    }
}
