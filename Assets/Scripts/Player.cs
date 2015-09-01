using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private bool canJump;
    private Animator anim;
    public int jumpCount;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
    }

    void Movement()
    {
        Vector2 moveVector = new Vector2(speed, 0);
        transform.Translate(moveVector * Time.deltaTime);
    }

    protected void Jump()
    {
        Vector2 jumpVector = new Vector2(0, jumpForce);
        //rb.velocity = jumpVector;
        GetComponent<Rigidbody2D>().velocity = jumpVector;
    }

    void OnCollisionEnter2D(Collision2D collide)
    {
        if (collide.gameObject.tag == "Ground")
        {
            canJump = true;
            jumpCount = 20;
        }
    }


    void PlayerInput()
    {
        if (Input.GetKey(KeyCode.X))
        {
            
            jumpCount-= 1;
            if (jumpCount <= 0)
            {
                canJump = false;
            }
            if (canJump == true)
            {
                Jump();
            }
                

        }


        //input D key.
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isTrue", true);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetBool("isTrue", false);
        }
    }
}
