using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fruit : MonoBehaviour
{
    public int fruitCount;
    public Text counter;

    private void Start()
    {
        fruitCount = 0;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruit"))
        {
            collision.gameObject.SetActive(false);
            ++fruitCount;
            counter.text = "" + fruitCount;
        }
    }

}
