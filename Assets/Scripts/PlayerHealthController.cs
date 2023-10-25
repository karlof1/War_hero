using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    private PlayerHealthBar healthBar;

    private void Start()
    {
        healthBar = GetComponent<PlayerHealthBar>();
    }
}
