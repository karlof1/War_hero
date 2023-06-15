using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampTrigger : MonoBehaviour
{
    private bool playerInTrigger;
    private bool state;
    public GameObject lamp;

    private void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            if (state)
            {
                TurnOffLight();
            }
            else
            {
                TurnOnLight();
            }
        }
    }

    private void TurnOnLight()
    {
        state = true;
        lamp.SetActive(true);
    }

    private void TurnOffLight()
    {
        state = false;
        lamp.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
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
}
