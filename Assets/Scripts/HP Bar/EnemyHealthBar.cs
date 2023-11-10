using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : HealthBar
{
    public override void Death()
    {
        base.Death();

        GetComponent<Enemy>().Die();
        //wywo³anie œmierci Enemy
    }
}
