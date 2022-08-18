using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    //Methods for the pause menu

    [SerializeField]
    private GameObject pauseScreen;

    private void Awake()
    {
        pauseScreen.SetActive(false);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !pauseScreen.activeSelf)
        {
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            Resume();
        }
    }
    public void Resume()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
