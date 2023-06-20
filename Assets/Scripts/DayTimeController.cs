using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTimeController : MonoBehaviour
{
    public GameObject clouds;
    public GameObject stars;
    void Update()
    {
        transform.Rotate(0.01f, 0f, 0f);
        if (transform.eulerAngles.x < 180f)
        {
            clouds.SetActive(true);
            stars.SetActive(false);
        }
        else
        {
            stars.SetActive(true);
            clouds.SetActive(false);
        }
    }
}