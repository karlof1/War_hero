using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangeWeapon : Weapon
{
    public float range;
    public int capacity;
    public abstract void Reload();
}