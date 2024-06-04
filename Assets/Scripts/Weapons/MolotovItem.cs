using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MolotovItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (WeaponController.molotovAvailable == false)
            {
                WeaponController.molotovAvailable = true;
                Destroy(gameObject);
            }
        }
    }
}
