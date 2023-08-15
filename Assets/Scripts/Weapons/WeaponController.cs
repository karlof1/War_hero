using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private Sniper sniper;
    [SerializeField] private Pistol pistol;
    [SerializeField] private Dagger dagger;

    private Weapon currentWeapon;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            sniper.gameObject.SetActive(!sniper.gameObject.activeInHierarchy);
            
            if (currentWeapon != null)
            {
                currentWeapon.gameObject.SetActive(false);
            }

            if (sniper.gameObject.activeInHierarchy)
            {
                currentWeapon = sniper;
            }
            else
            {
                currentWeapon = null;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            pistol.gameObject.SetActive(!pistol.gameObject.activeInHierarchy);

            if (currentWeapon != null)
            {
                currentWeapon.gameObject.SetActive(false);
            }

            if (pistol.gameObject.activeInHierarchy)
            {
                currentWeapon = pistol;
            }
            else
            {
                currentWeapon = null;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            dagger.gameObject.SetActive(!dagger.gameObject.activeInHierarchy);

            if (currentWeapon != null)
            {
                currentWeapon.gameObject.SetActive(false);
            }

            if (dagger.gameObject.activeInHierarchy)
            {
                currentWeapon = dagger;
            }
            else
            {
                currentWeapon = null;
            }
        }

        if (currentWeapon != null && Input.GetKeyDown(KeyCode.Mouse0))
        {
            currentWeapon.Use();
        }
    }
}
