using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public static Data Instance;
    public int highest;
    public int scoreholder;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        GameObject[] objs = GameObject.FindGameObjectsWithTag("canvas");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        //scoreholder = Fruit.instance.fruitCount;
        if (scoreholder > highest) highest = scoreholder;
    }

   


}
