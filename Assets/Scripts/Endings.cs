using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Endings : MonoBehaviour
{
    [SerializeField]
    private GameObject ending1;

    [SerializeField]
    private GameObject ending2;

    [SerializeField]
    private GameObject ending3;

    [SerializeField]
    private Button button;
    void Start()
    {
        //Checks number of squash, gives ending.
        switch (StaticVar.GetSquash())
        {
            case 10:
                ending1.SetActive(false);
                ending2.SetActive(true);
                ending3.SetActive(false);
                break;

            case 0:
                ending1.SetActive(false);
                ending2.SetActive(false);
                ending3.SetActive(true);
                break;

            default:
                ending1.SetActive(true);
                ending2.SetActive(false);
                ending3.SetActive(false);
                break;
        }
        
    }

    //Method for returning to main menu
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
}
