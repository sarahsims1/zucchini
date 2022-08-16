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
    private GameObject ending4;

    [SerializeField]
    private Button button;
    void Start()
    {

        button.interactable = false;

        switch (StaticVar.GetSquash())
        {
            case 8:
                ending1.SetActive(false);
                ending2.SetActive(true);
                ending3.SetActive(false);
                ending4.SetActive(false);
                break;

            case 0:
                ending1.SetActive(false);
                ending2.SetActive(false);
                ending3.SetActive(true);
                ending4.SetActive(false);
                break;

            default:
                ending1.SetActive(true);
                ending2.SetActive(false);
                ending3.SetActive(false);
                ending4.SetActive(false);
                break;
        }

        if(StaticVar.GetFailed())
        {
            ending1.SetActive(false);
            ending2.SetActive(false);
            ending3.SetActive(false);
            ending4.SetActive(true);
            StartCoroutine(Wait30());
        }

        StaticVar.SetDirt(0);
        StaticVar.SetSeeds(0);
        StaticVar.SetSquash(0);
        StaticVar.SetFailed(false);
    }

    private IEnumerator Wait30()
    {
        yield return new WaitForSecondsRealtime(30);
        button.interactable = true;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
}
