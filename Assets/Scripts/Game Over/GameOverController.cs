using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public void LoadGameplayScene()
    {
        SceneManager.LoadScene("Main");
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
