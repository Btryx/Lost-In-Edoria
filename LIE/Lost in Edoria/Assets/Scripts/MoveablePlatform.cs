using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveablePlatform : MonoBehaviour
{
    private float movement = 2f;
    char direction = 'R';
    public Vector3 startpos;
    private Rigidbody2D platformBody;
    public bool rightstart;

    private void Awake()
    {
        startpos = transform.position;
        if (rightstart == true) direction = 'R';
        else { direction = 'L'; }
    }
    private void Start()
    {
        platformBody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (direction == 'R')
        {
            platformBody.velocity = new Vector2(movement, platformBody.velocity.y);
        }
        else if (direction == 'L')
        {
            platformBody.velocity = new Vector2(-movement, platformBody.velocity.y);
        }

        if (gameObject.transform.position.x >= startpos.x + 3) direction = 'L';
        else if (gameObject.transform.position.x <= startpos.x - 3) direction = 'R';

    }
   /* private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            if (direction == 'R') direction = 'L';
            else direction = 'R';
        }
    }*/
}
