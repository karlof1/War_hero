using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Sniper : RangeWeapon
{
    public override void Reload()
    {

    }

    public override void Use()
    {
        transform.localPosition = idlePosition;
        transform.localEulerAngles = idleRotation;

        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOLocalMove(attackPosition, 0.5f));
        sequence.Join(transform.DOLocalRotate(attackRotation, 0.5f));
        sequence.AppendInterval(0.1f);
        sequence.Append(transform.DOLocalMove(idlePosition, 0.5f));
        sequence.Join(transform.DOLocalRotate(idleRotation, 0.5f));
    }
    public void Aim()
    {
        //wywo³anie celownika z lunet¹ do momentu strza³u
        //zmiana Field of view kamery z 60 na 10
    }

    public void CancelAim()
    {
        //powrót do podstawowego widoku
        //zmiana Field of view kamery z 10 na 60
    }
}
