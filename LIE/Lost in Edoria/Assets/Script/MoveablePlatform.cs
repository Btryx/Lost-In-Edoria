using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveablePlatform : MonoBehaviour
{
    private float movement = 2f;
    char direction = 'R';
    private Rigidbody2D platformBody;
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

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            if (direction == 'R') direction = 'L';
            else direction = 'R';
        }
    }
}
