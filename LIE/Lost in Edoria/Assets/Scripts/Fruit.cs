using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fruit : MonoBehaviour
{
    public static Fruit instance;
    public int fruitCount;
    public Text counter;

    private void Start()
    {
        fruitCount = 0;

        if(instance == null)
        {
            instance = this;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruit"))
        {
            collision.gameObject.SetActive(false);
            ++fruitCount;
            Data.Instance.score += 10;
            counter.text = "" + fruitCount;
            Audio.instance.playCollect();
        }
    }

}
