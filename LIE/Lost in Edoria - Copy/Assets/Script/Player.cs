using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    private float speed = 10f;
    private float jump = 14f;

    private float movementX;

    public Rigidbody2D myBody;

    public SpriteRenderer sr;

    private Animator anim;

    private string WALK_ANIM = "Walk";
    private string JUMP_ANIM = "Jump";

    bool touchGround;

    public int life;
    public int maxLife = 3;

    public GameObject[] hearts;

    bool haveKey;



    private void Awake()
    {
        
        myBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        life = maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        Animate();
        PlayerJump();
    }

    private void FixedUpdate()
    {
        if(transform.position.y < -16)
        {
            Destroy(this.gameObject);
        }
    }

    void PlayerMovement()
    {
        movementX = Input.GetAxis("Horizontal");

        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * speed;
    }

    void Animate()
    {
        if(movementX > 0) { anim.SetBool(WALK_ANIM, true); }
        else if (movementX == 0) { anim.SetBool(WALK_ANIM, false); }
        else{ anim.SetBool(WALK_ANIM, true); }

        if (movementX < 0) sr.flipX = true;
        else if (movementX > 0) sr.flipX = false;
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && touchGround)
        {
            touchGround = false;
            myBody.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
            anim.SetBool(JUMP_ANIM, true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        { touchGround = true; }

        if (collision.gameObject.CompareTag("Ground"))
        {
            anim.SetBool(JUMP_ANIM, false);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1);

            if (GameObject.FindGameObjectWithTag("Enemy").transform.position.x > gameObject.transform.position.x )
            {
                myBody.AddForce(new Vector2(-5f, 10f), ForceMode2D.Impulse);
            }
            else
            {
                myBody.AddForce(new Vector2(10f, 5f), ForceMode2D.Impulse);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            haveKey = true;
        }

        if (collision.gameObject.CompareTag("FinishLine") && haveKey)
        {
            SceneManager.LoadScene(2);
        }
    }

    void TakeDamage(int damage)
    {
        life -= damage;

        if (life < 1) hearts[0].gameObject.SetActive(false);
        else if (life < 2) hearts[1].gameObject.SetActive(false);
        else if (life < 3) hearts[2].gameObject.SetActive(false);

        if (life == 0)
        {
            Destroy(gameObject);
        }
    }






}
