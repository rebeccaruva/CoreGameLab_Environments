using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOne : MonoBehaviour
{

    private Rigidbody2D rib;
    private float speed = 5f;
    private float jumpForce = 800f;
    private Animator anim;
    private SpriteRenderer spur;
    public LayerMask whatIsGround;
    public Transform footsies;
    public bool grounded;
    int direction = 1;

    public int jumpTotal = 1;
    private int jumpCount = 0;
    private float gravity;

    // Use this for initialization
    void Start()
    {
        rib = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spur = GetComponent<SpriteRenderer>();
        gravity = rib.gravityScale;

    }

    // Update is called once per frame
    void Update()
    {
        //if (this.gameObject.CompareTag("PlayerPicto"))
        //if (Input.GetKey(KeyCode.S) || Input.GetKey("down"))
        //{
        //    anim.SetBool("Hide", true);
        //    this.gameObject.tag = "PlayerHide";
        //}
        //else
        //{
        //    anim.SetBool("Hide", false);
        //    this.gameObject.tag = "PlayerPicto";
        //}


        float xSpeed = Input.GetAxisRaw("Horizontal") * speed;

        anim.SetFloat("Speed", Mathf.Abs(xSpeed));
        rib.velocity = new Vector2(xSpeed, rib.velocity.y);
        

        grounded = Physics2D.OverlapCircle(footsies.position, 0.5f, whatIsGround);
        anim.SetBool("Jumping", !grounded);

        if (grounded)
        {
            jumpCount = jumpTotal;
        }


        if (Input.GetButtonDown("Jump") && jumpCount > 0 && this.gameObject.CompareTag("PlayerPicto"))
        {
            rib.AddForce(new Vector2(0, jumpForce)); //no x since you are just adding a force
            rib.velocity = new Vector2(rib.velocity.x, 0); //makes the second jump just as strong!
            jumpCount--;
        }

        if (xSpeed < 0)
        {
            spur.flipX = true;
            direction = 1;
        }
        else if (xSpeed > 0)
        {
            spur.flipX = false;
            direction = -1;
        }
    }
}
