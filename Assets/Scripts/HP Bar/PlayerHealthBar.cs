using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBar : HealthBar
{
    public override void Death()
    {
        base.Death();

        //wywo³anie œmierci gracza
    }
}