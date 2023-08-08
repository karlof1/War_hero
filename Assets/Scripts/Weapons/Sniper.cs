using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : RangeWeapon
{
    public override void Reload()
    {

    }

    public override void Use()
    {
        Debug.Log("sniper used");
    }
}
