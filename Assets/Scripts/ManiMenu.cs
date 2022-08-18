using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ManiMenu : MonoBehaviour
{

    /// <summary>
    /// A script with methods for switching screens and scenes
    /// </summary>
    [SerializeField]
    private GameObject main;

    [SerializeField]
    private GameObject credits;

    [SerializeField]
    private GameObject explainationScreen;
    public void Switch()
    {
        main.SetActive(false);
        explainationScreen.SetActive(true);
    }

    public void Play()
    {
        StaticVar.SetDirt(0);
        StaticVar.SetSeeds(0);
        StaticVar.SetSquash(0);
        SceneManager.LoadScene("Game"); 
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Credits()
    {
        credits.SetActive(true);
        main.SetActive(false);
    }

    public void Back()
    {
        credits.SetActive(false);
        main.SetActive(true);
    }
}
