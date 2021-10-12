using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttoncollider : MonoBehaviour
{
    public static buttoncollider instance;
    public bool DoorShouldMove = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TriggerButton.instance.anim.SetBool(TriggerButton.instance.STEPPED_ANIM, true);
            DoorShouldMove = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            TriggerButton.instance.anim.SetBool(TriggerButton.instance.STEPPED_ANIM, false);
            DoorShouldMove = false;
        }
    }
}
