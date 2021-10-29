using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toby : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(true);
    }

    void Update()
    {
        if (Dialogue.instance.Toby)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }

    }
}
