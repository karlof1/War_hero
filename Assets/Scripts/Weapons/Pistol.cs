using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Pistol : RangeWeapon
{
    public override void Reload()
    {

    }

    public override void Use()
    {
        transform.localPosition = idlePosition;
        transform.localEulerAngles = idleRotation;

        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOLocalMove(attackPosition, 0.05f));
        sequence.Join(transform.DOLocalRotate(attackRotation, 0.05f));
        sequence.AppendInterval(0.1f);
        sequence.Append(transform.DOLocalMove(idlePosition, 0.05f));
        sequence.Join(transform.DOLocalRotate(idleRotation, 0.05f));
    }
}
