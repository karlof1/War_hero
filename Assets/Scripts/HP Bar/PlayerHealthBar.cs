using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthBar : HealthBar
{
    public override void Death()
    {
        base.Death();

        LoadGameOverScene();
    }

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOver");
    }
}