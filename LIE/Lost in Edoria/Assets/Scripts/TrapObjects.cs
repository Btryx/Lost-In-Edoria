using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapObjects : MonoBehaviour
{
    private BoxCollider2D boxc;

    // Start is called before the first frame update
    void Start()
    {
        boxc = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.Instance.TakeDamage(3);
        }
    }
}
