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
    [SerializeField] private FragGrenade fragGrenade;
    [SerializeField] private FlashGrenade flashGrenade;
    [SerializeField] private SmokeGrenade smokeGrenade;
    [SerializeField] private Molotov molotov;

    private Weapon currentWeapon;

    public static bool fragGrenadeAvailable;
    [SerializeField] private Image fragGrenadeIcon;
    public static bool flashGrenadeAvailable;
    [SerializeField] private Image flashGrenadeIcon;
    public static bool smokeGrenadeAvailable;
    [SerializeField] private Image smokeGrenadeIcon;
    public static bool molotovAvailable;
    [SerializeField] private Image molotovIcon;

    private int grenadeSlotIndex = 0;

    public static int ammoCapacity;
    [SerializeField] private TMP_Text ammoValue;

    [Header("Center Aim")]
    [SerializeField] private Image centerAim;

    private void Start()
    {
        SetAmmo(250);
    }

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
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if(fragGrenadeAvailable)
            {
                if (currentWeapon != null)
                {
                    currentWeapon.gameObject.SetActive(false);

                    if (currentWeapon == sniper)
                    {
                        sniper.CancelAim();
                    }
                }

                currentWeapon = fragGrenade;
                currentWeapon.gameObject.SetActive(true);
                centerAim.gameObject.SetActive(true);
            }
            else if (flashGrenadeAvailable)
            {
                if (currentWeapon != null)
                {
                    currentWeapon.gameObject.SetActive(false);

                    if (currentWeapon == sniper)
                    {
                        sniper.CancelAim();
                    }
                }

                currentWeapon = flashGrenade;
                currentWeapon.gameObject.SetActive(true);
                centerAim.gameObject.SetActive(true);
            }
            else if (smokeGrenadeAvailable)
            {
                if (currentWeapon != null)
                {
                    currentWeapon.gameObject.SetActive(false);

                    if (currentWeapon == sniper)
                    {
                        sniper.CancelAim();
                    }
                }

                currentWeapon = smokeGrenade;
                currentWeapon.gameObject.SetActive(true);
                centerAim.gameObject.SetActive(true);
            }
            else if (molotovAvailable)
            {
                if (currentWeapon != null)
                {
                    currentWeapon.gameObject.SetActive(false);

                    if (currentWeapon == sniper)
                    {
                        sniper.CancelAim();
                    }
                }

                currentWeapon = molotov;
                currentWeapon.gameObject.SetActive(true);
                centerAim.gameObject.SetActive(true);
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

    public void SetAmmo(int amount)
    {
        ammoCapacity = amount;
        ammoValue.text = ammoCapacity.ToString();
    }
}