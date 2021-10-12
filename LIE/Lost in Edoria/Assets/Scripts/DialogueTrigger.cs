using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public BoxCollider2D boxc;
    public DiaClass d;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ball") Dialogue.instance.StartDialogue(d);
    }
}
