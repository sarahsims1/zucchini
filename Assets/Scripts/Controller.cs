
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private float jumpHeight;

    [SerializeField]
    private int jumpCount;

    private int timesJumped;
    void Start()
    {
        
    }


    void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;
        if(timesJumped<jumpCount && Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
            timesJumped++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("platforms"))
        {
            timesJumped = 0;
        }
    }
}
