using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public static Player Instance;

    private float speed = 10f;
    private float jump = 14f;

    private float movementX;

    public Rigidbody2D myBody;

    public SpriteRenderer sr;

    private Animator anim;

    private BoxCollider2D boxc; 

    private string WALK_ANIM = "Walk";
    private string JUMP_ANIM = "Jump";

    public bool touchGround;

    public int life;
    public int maxLife = 3;

    public GameObject[] hearts;

    bool haveKey;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        boxc = GetComponent<BoxCollider2D>();

        if (Instance == null)
        {
            Instance = this;
        }
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
            anim.SetBool(JUMP_ANIM, true);
            myBody.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
            Audio.instance.playJump();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        { touchGround = true;
          anim.SetBool(JUMP_ANIM, false);
        }

        if (collision.gameObject.CompareTag("rugo"))
        {
            touchGround = false;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1);
            //death.Play();

            if (collision.gameObject.transform.position.x > gameObject.transform.position.x )
            {
                myBody.AddForce(new Vector2(-5f, 5f), ForceMode2D.Impulse);
            }
            else
            {
                myBody.AddForce(new Vector2(5f, 5f), ForceMode2D.Impulse);
            }
        }
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(GameManager.Instance.level);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            haveKey = true;
            Audio.instance.playCollect();
        }

        if (collision.gameObject.CompareTag("FinishLine") && haveKey)
        {
            Audio.instance.playfinish();
            GameManager.Instance.level++;
            StartCoroutine(ExecuteAfterTime(2));

        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            myBody.AddForce(new Vector2(0, 15f), ForceMode2D.Impulse);
            Audio.instance.playkill();
        }
    }
    public void TakeDamage(int damage)
    {
        life -= damage;

        if (life <= 0)
        {
            for (int i = 0; i < hearts.Length; i++)
            {
                hearts[i].SetActive(false);
            }
            Audio.instance.playDeath();
            GameManager.Instance.Death();
            Destroy(gameObject);
        }
        else if (life < 1) hearts[0].gameObject.SetActive(false);
        else if (life < 2) hearts[1].gameObject.SetActive(false);
        else if (life < 3) hearts[2].gameObject.SetActive(false);
    }



}
