using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public GameObject pauseCanvas;
    void Start()
    {
        pauseCanvas.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseCanvas.SetActive(!pauseCanvas.activeInHierarchy);
        }
    }

    public void Resume()
    {
        pauseCanvas.SetActive(false);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
