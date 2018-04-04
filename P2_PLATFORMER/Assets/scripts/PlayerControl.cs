using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour {

    private Rigidbody2D rib;
    private float speed = 5f;
    private float jumpForce = 800f;
    private Animator anim;
    private SpriteRenderer spur;
    private bool bat;
    public LayerMask whatIsGround;
    public Transform footsies;
    public bool grounded;
    int direction = 1;
    public GameObject essence;

    public int jumpTotal = 1;
    private int jumpCount = 0;
    private float gravity;

    private bool dashing = false;
    public float dashTime = 0.3f; //seconds

    private int life = 5;
    public int totalLife = 5;
    public GameObject lifebar; //default sprite looks empty
    public Transform lifeImg;
    float timer;

    // Use this for initialization
    void Start () {
        rib = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spur = GetComponent<SpriteRenderer>();
        gravity = rib.gravityScale;
        bat = false;

        for (int i = 0; i < totalLife; i++)
        {
            AddLifeBar();
        }
        UpdateLifeBar();
    }
	
	// Update is called once per frame
	void Update () {
        //if (this.gameObject.CompareTag("PlayerPicto"))
        timer += Time.deltaTime;
        int seconds = (int)(timer % 60);
        if ((Input.GetKey(KeyCode.S) || Input.GetKey("down")))
        {
            anim.SetBool("Hide", true);
            this.gameObject.tag = "PlayerHide";

            if (seconds > 7)
            {
                timer = 0;
                seconds = 0;
                anim.SetBool("Hide", false);
                this.gameObject.tag = "PlayerPicto";
                life--;
                UpdateLifeBar();
            }
        }
        else
        {
            anim.SetBool("Hide", false);
            this.gameObject.tag = "PlayerPicto";
        }

        //if ((Input.GetKeyDown(KeyCode.W) && !bat) || (Input.GetKeyDown("up") && !bat))
        //{
        //    anim.SetBool("Bat", true);
        //    bat = true;
        //    this.gameObject.tag = "PlayerBat";
        //}
        //else if ((bat && Input.GetKeyDown(KeyCode.W)) || (bat && Input.GetKeyDown("up")))
        //{
        //    anim.SetBool("Bat", false);
        //    bat = false;
        //    this.gameObject.tag = "PlayerPicto";
        //}

        if (Input.GetButtonDown("Fire3") && !dashing)
        {
            dashing = true;
            rib.gravityScale = 0;
            Invoke("DashTimer", dashTime);
        }

        float xSpeed = Input.GetAxisRaw("Horizontal") * speed;

        if (dashing)
        {
            if (spur.flipX)
            {
                rib.velocity = new Vector2(speed * -3, 0);
            } else
            {
                rib.velocity = new Vector2(speed * 3, 0);
            }
        } else
        {
            anim.SetFloat("Speed", Mathf.Abs(xSpeed));
            rib.velocity = new Vector2(xSpeed, rib.velocity.y);
        }

        grounded = Physics2D.OverlapCircle(footsies.position, 0.5f, whatIsGround);
        anim.SetBool("Jumping", !grounded);

        if (grounded)
        {
            jumpCount = jumpTotal;
        }


        if(Input.GetButtonDown("Jump") && jumpCount > 0 && this.gameObject.CompareTag("PlayerPicto")) {
            rib.AddForce(new Vector2(0, jumpForce)); //no x since you are just adding a force
            rib.velocity = new Vector2(rib.velocity.x, 0); //makes the second jump just as strong!
            jumpCount--;
        }

        if (xSpeed < 0)
        {
            spur.flipX = true;
            direction = 1;
        } else if (xSpeed > 0)
        {
            spur.flipX = false;
            direction = -1;
        }

    }
    
    void DashTimer()
    {
        rib.gravityScale = gravity;
        dashing = false;
    }

    void AddLifeBar()
    {
        Transform newImg = Instantiate(lifeImg) as Transform;
        newImg.SetParent(lifebar.transform);
        newImg.localScale = new Vector3(1, 1, 1);
    }

    void UpdateLifeBar()
    {
        Image[] img_ary = lifebar.GetComponentsInChildren<Image>();
        for (int i = 0; i < img_ary.Length; i++)
        {
            if (i < life)
            {
                img_ary[i].color = new Color(0f, 1f, 1f);
            }
            else
            {
                img_ary[i].color = Color.white;
            }
        }

        if (life == 0)
        {
            Scene scene = SceneManager.GetActiveScene();
            if (scene.name == "3-earth")
            {
                SceneManager.LoadScene("6-restart2");
            }
            if (scene.name == "4-ball")
            {
                SceneManager.LoadScene("7-restart3");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Health"))
        { //gives you 1 more bar for life
            life++;
            UpdateLifeBar();
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Life"))
        { //gives you an empty capsule
            totalLife++;
            AddLifeBar();

            //life++;
            //UpdateLifeBar(); //gives you automatically full one

            Destroy(other.gameObject);
        }

        if (other.CompareTag("Enemy") && !this.gameObject.CompareTag("PlayerHide"))
        {
            life--;
            UpdateLifeBar();
        }

        if (other.gameObject.CompareTag("EssenceCollect") && (Input.GetButton("Fire1")))
        {
            //anim.SetTrigger("Shoot");
            //Vector2 spawnPos = new Vector2(transform.position.x - direction, transform.position.y);
            //GameObject essencePrefab = Instantiate(essence, spawnPos, Quaternion.identity);

            //essencePrefab.GetComponent<SpriteRenderer>().flipX = spur.flipX;
            //essencePrefab.GetComponent<Rigidbody2D>().AddForce(transform.right * 500f * -direction);

            Debug.Log("im here");

            life++;
            UpdateLifeBar();
        }
    }
}
