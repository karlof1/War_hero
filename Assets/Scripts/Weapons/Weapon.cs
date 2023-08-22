using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public int attackDamage;

    [Header("Transform")]
    public Vector3 idlePosition;
    public Vector3 idleRotation;
    public Vector3 attackPosition;
    public Vector3 attackRotation;

    public abstract void Use();
}