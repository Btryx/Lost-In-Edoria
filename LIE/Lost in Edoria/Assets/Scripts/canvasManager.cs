using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasManager : MonoBehaviour
{
    public static canvasManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        GameObject[] objs = GameObject.FindGameObjectsWithTag("canvas");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
