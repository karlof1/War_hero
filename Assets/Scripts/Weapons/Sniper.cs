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

        Vector3 centerScreenPoint = new Vector3(Screen.width/2f, Screen.height/2f, 0f);

        Ray ray = Camera.main.ScreenPointToRay(centerScreenPoint);

        RaycastHit hitInfo;

        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 5f);

        if(Physics.Raycast(ray, out hitInfo, 100f))
        {
            Enemy enemy = hitInfo.collider.GetComponent<Enemy>();
            Debug.Log("wystrzelono promieñ");

            if(enemy != null)
            {
                enemy.healthBar.SubtractHealth(60);
                Debug.Log("zadano obra¿enia");
            }
        }
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
