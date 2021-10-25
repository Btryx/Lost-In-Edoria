using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : MonoBehaviour
{
    public static Question Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        this.gameObject.SetActive(false);
    }
}
