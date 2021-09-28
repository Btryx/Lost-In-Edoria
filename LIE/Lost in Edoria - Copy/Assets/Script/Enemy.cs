using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour{

    private float speed = 5f;
    private Rigidbody2D enemyBody;
    private bool Direction;

    private void Awake()
    {
        enemyBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Direction)
        {
            enemyBody.velocity = new Vector2(speed, enemyBody.velocity.y);
        }
        else if(!Direction)
        {
            enemyBody.velocity = new Vector2(-speed, enemyBody.velocity.y);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            Direction = !Direction;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            Direction = !Direction;
        }
    }
}
