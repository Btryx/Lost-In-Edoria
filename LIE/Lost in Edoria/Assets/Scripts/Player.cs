using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public static Player Instance;
    public DiaClass d;

    private float speed = 10f;
    private float jump = 14f;
    private float movementX;
    public Rigidbody2D myBody;
    public SpriteRenderer sr;
    private Animator anim;
    private BoxCollider2D boxc;
    public int TouchedFinishLine;
    

    private string WALK_ANIM = "Walk";
    private string JUMP_ANIM = "Jump";

    public bool touchGround;

    public int life;
    public int maxLife = 3;

    public GameObject[] hearts;

    public bool haveKey;

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
        Data.Instance.timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        Animate();
        PlayerJump();

        Data.Instance.timer += Time.deltaTime;
    }
    private void FixedUpdate()
    {
        if(transform.position.y < -36)
        {
            Destroy(this.gameObject);
        }
    }
    void PlayerMovement()
    {
        if (Dialogue.instance.dialogueIsPlaying)
        {
            return;
        }
        movementX = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * speed;
    }

    void Animate()
    {
        if (Dialogue.instance.dialogueIsPlaying)
        {
            anim.SetBool(WALK_ANIM, false);
            return;
        }
        if (movementX > 0) { anim.SetBool(WALK_ANIM, true); }
        else if (movementX == 0) { anim.SetBool(WALK_ANIM, false); }
        else{ anim.SetBool(WALK_ANIM, true); }

        if (movementX < 0) sr.flipX = true;
        else if (movementX > 0) sr.flipX = false;
    }
    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && touchGround)
        {
            if (Dialogue.instance.dialogueIsPlaying)
            {
                return;
            }
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
                myBody.velocity = new Vector3(-10f, 10f, 0);
            }
            else
            {
                myBody.velocity = new Vector3(10f, 10f, 0);
            }
        }
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator WaitBeforeDeath(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);

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
            TouchedFinishLine++;
            Data.Instance.timeHolder += Data.Instance.timer;
            Data.Instance.timerscore = 150 - (Data.Instance.timer);
            Data.Instance.scoreholder += Data.Instance.score;
            Data.Instance.score = 0;
            Data.Instance.scoreholder += Data.Instance.timerscore;
            Data.Instance.timerscore = 0;
            StartCoroutine(ExecuteAfterTime(1f));
        }

        if(collision.gameObject.CompareTag("House"))
        {
            TouchedFinishLine = -1;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            myBody.velocity = new Vector3(0, 10, 0);
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
            anim.SetBool(JUMP_ANIM, true);
            myBody.AddForce(new Vector2(0, 4.5f), ForceMode2D.Impulse); 
            StartCoroutine(WaitBeforeDeath(0.5f));
        }
        else if (life < 1) hearts[0].gameObject.SetActive(false);
        else if (life < 2) hearts[1].gameObject.SetActive(false);
        else if (life < 3) hearts[2].gameObject.SetActive(false);
    }

}
