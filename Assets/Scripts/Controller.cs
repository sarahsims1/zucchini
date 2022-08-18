
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private float jumpHeight;

    //How many times are we allowed to jump?
    [SerializeField]
    private int jumpCount;

    //The side collsions push player away from wall.
    [SerializeField]
    private float sideBounciness;

    private int timesJumped;

    public bool onGround;

    private Rigidbody2D rb;

    private SpriteRenderer sr;

    //Which direction are we moving?
    private float movement;

    //Are we colliding on the sides?
    private bool sideCollision;

    private Vector3 m_Velocity = Vector3.zero;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        //Movement input
        movement = Input.GetAxis("Horizontal");

        //Flips sprite
        if (movement > 0) sr.flipX = true; if(movement<0) sr.flipX = false;

        //If we collide with a not-platform, we bounce back.
        if (sideCollision) BounceBack();

        //I have no animations, but I must move
        Move();

        //We can jump if we haven't met our jump count.
        if(timesJumped<jumpCount && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if(timesJumped >= 1 && rb.velocity.y == 0)
        {
            //prevents player from getting stuck in collider (idk why it happens, but this works)
            transform.position += new Vector3(0, 0.01f);
        }
    }

    //Methods for movement
    public void Move()
    {
        transform.position += new Vector3(movement * movementSpeed * Time.deltaTime, 0);
    }

    public void BounceBack()
    {
        rb.AddForce(new Vector2(sideBounciness * -movement, 0), ForceMode2D.Impulse);
    }

    private void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
        timesJumped++;
    }

    //Checks for collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("platforms")|| collision.gameObject.tag.Equals("ground") || collision.gameObject.tag.Equals("leaf"))
        {
            timesJumped = 0;
        }
        else
        {
            sideCollision = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("ground"))
        {
            onGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("ground") || collision.gameObject.tag.Equals("platform") || collision.gameObject.tag.Equals("leaf"))
        {
            onGround = false;
        }
        else
        {
            sideCollision = false;
        }
    }
}
