using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : RangeWeapon
{
    public override void Reload()
    {

    }

    public override void Use()
    {
        Debug.Log("pistol used");
    }
}
