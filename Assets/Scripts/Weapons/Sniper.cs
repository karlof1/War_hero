using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Sniper : RangeWeapon
{
    public bool isAiming = false;
    [SerializeField] private Image sniperAim;

    public override void Reload()
    {

    }

    public override void Use()
    {
        base.Use();

        CancelAim();

        transform.localPosition = idlePosition;
        transform.localEulerAngles = idleRotation;

        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOLocalMove(attackPosition, 0.1f));
        sequence.Join(transform.DOLocalRotate(attackRotation, 0.1f));
        sequence.AppendInterval(0.1f);
        sequence.Append(transform.DOLocalMove(idlePosition, 0.5f));
        sequence.Join(transform.DOLocalRotate(idleRotation, 0.5f));
    }
    public void Aim()
    {
        isAiming = true;
        sniperAim.gameObject.SetActive(true);
        Camera.main.fieldOfView = 10f;
    }

    public void CancelAim()
    {
        isAiming = false;
        sniperAim.gameObject.SetActive(false);
        Camera.main.fieldOfView = 60f;
    }
}
