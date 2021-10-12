using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerButton : MonoBehaviour
{
    public static TriggerButton instance;
    public Animator anim;
    public string STEPPED_ANIM = "isStepped";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        anim = GetComponent<Animator>();

    }

}
