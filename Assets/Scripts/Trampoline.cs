using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
using UnityEngine;

public class Trampoline : MonoBehaviour
{

    //Serves as an end point, transitions to the win/lose screen
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private TMP_Text text;
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == player)
        {
            StartCoroutine(Finish());
        }
    }

    private IEnumerator Finish()
    {
        text.text = "FINISH!";
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadScene("WinLose");
    }
}
