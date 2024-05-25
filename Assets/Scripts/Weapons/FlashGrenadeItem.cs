using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashGrenadeItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (WeaponController.fragGrenadeAvailable == false)
            {
                WeaponController.fragGrenadeAvailable = true;
                Destroy(gameObject);
            }
        }
    }
}
