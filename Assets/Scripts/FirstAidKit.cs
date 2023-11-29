using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerHealthBar healthBar = FindObjectOfType<PlayerHealthBar>();

            if (healthBar.healthValue < 100)
            {
                healthBar.AddHealth(90);
                Destroy(gameObject);
            }
        }
    }
}
