using UnityEngine.SceneManagement;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == player && player.GetComponent<Rigidbody2D>().velocity == new Vector2(0,0))
        {
            SceneManager.LoadScene("WinLose");
        }
    }
}
