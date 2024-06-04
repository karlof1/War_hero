using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashGrenadeItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (WeaponController.flashGrenadeAvailable == false)
            {
                WeaponController.flashGrenadeAvailable = true;
                Destroy(gameObject);
            }
        }
    }
}