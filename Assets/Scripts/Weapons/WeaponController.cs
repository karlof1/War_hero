using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private Sniper sniper;
    [SerializeField] private Pistol pistol;
    [SerializeField] private Dagger dagger;

    private Weapon currentWeapon;

    public static int ammoCapacity = 250;
    [SerializeField] private TMP_Text ammoValue;

    [Header("Center Aim")]
    [SerializeField] private Image centerAim;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            sniper.gameObject.SetActive(!sniper.gameObject.activeInHierarchy);
            centerAim.gameObject.SetActive(false);

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

                if(currentWeapon == sniper)
                {
                    sniper.CancelAim();
                }
            }

            if (pistol.gameObject.activeInHierarchy)
            {
                currentWeapon = pistol;
                centerAim.gameObject.SetActive(true);
            }
            else
            {
                currentWeapon = null;
                centerAim.gameObject.SetActive(false);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            dagger.gameObject.SetActive(!dagger.gameObject.activeInHierarchy);

            if (currentWeapon != null)
            {
                currentWeapon.gameObject.SetActive(false);

                if (currentWeapon == sniper)
                {
                    sniper.CancelAim();
                }
            }

            if (dagger.gameObject.activeInHierarchy)
            {
                currentWeapon = dagger;
                centerAim.gameObject.SetActive(true);
            }
            else
            {
                currentWeapon = null;
                centerAim.gameObject.SetActive(false);
            }
        }

        if (currentWeapon != null && Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(currentWeapon is RangeWeapon)
            {
                if(ammoCapacity > 0)
                {
                    currentWeapon.Use();
                    SubtractAmmo(1);
                }
            }
            else
            {
                currentWeapon.Use();
            }
        }

        if (currentWeapon == sniper && Input.GetKeyDown(KeyCode.Mouse1))
        {
            if(sniper.isAiming)
            {
                sniper.CancelAim();
            }
            else
            {
                sniper.Aim();
            }
        }
    }

    public void AddAmmo(int amount)
    {
        ammoCapacity += amount;
        ammoValue.text = ammoCapacity.ToString();
    }

    public void SubtractAmmo(int amount)
    {
        ammoCapacity -= amount;

        if(ammoCapacity < 0)
        {
            ammoCapacity = 0;
        }

        ammoValue.text = ammoCapacity.ToString();
    }
}