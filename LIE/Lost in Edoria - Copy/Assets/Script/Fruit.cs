using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fruit : MonoBehaviour
{
    [SerializeField]
    public int fruitCount;

    private void Start()
    {
        fruitCount = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            ++fruitCount;
        }
    }

  
}
