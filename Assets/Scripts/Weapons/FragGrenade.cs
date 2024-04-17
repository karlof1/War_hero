using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FragGrenade : ThrowableWeapon
{

    public override void Use()
    {
        base.Use();

        GameObject grenade = Instantiate(grenadePrefab, throwPoint.position, throwPoint.rotation);
        //prefab granatów musi mieæ rigidbody z wy³¹czonym usegravity
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(throwPoint.forward * throwForce, ForceMode.VelocityChange);
        rb.useGravity = true;
        //obs³u¿yæ metodê explode po odczekaniu opóŸnienia w coroutine

        //transform.localPosition = idlePosition;
        //transform.localEulerAngles = idleRotation;

        //Sequence sequence = DOTween.Sequence();
        //sequence.Append(transform.DOLocalMove(attackPosition, 0.05f));
        //sequence.Join(transform.DOLocalRotate(attackRotation, 0.05f));
        //sequence.AppendInterval(0.1f);
        //sequence.Append(transform.DOLocalMove(idlePosition, 0.05f));
        //sequence.Join(transform.DOLocalRotate(idleRotation, 0.05f));

        Vector3 centerScreenPoint = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);

        Ray ray = Camera.main.ScreenPointToRay(centerScreenPoint);

        RaycastHit hitInfo;

        // Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 5f);

        if (Physics.Raycast(ray, out hitInfo, 30f))
        {
            Enemy enemy = hitInfo.collider.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.healthBar.SubtractHealth(30);
            }

        }
    }
}