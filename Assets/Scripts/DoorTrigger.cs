using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorTrigger : MonoBehaviour
{
    private bool playerInTrigger;
    private bool state;
    public Transform doorPivot;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInTrigger = false;
        }
    }

    private void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            if(state)
            {
                CloseDoor();
            }
            else
            {
                OpenDoor();
            }
        }
    }

    private void OpenDoor()
    {
        state = true;
        doorPivot.DOLocalRotate(new Vector3(0f, -110f, 0f), 1f);
    }

    private void CloseDoor()
    {
        state = false;
        doorPivot.DOLocalRotate(new Vector3(0f, 0f, 0f), 1f);
    }
}
