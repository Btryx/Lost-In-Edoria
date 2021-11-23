using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public BoxCollider2D boxc;
    public DiaClass d;
    public bool IsFirst;

    private void Awake()
    {
        IsFirst = true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.gameObject.tag != "Gate" && collision.gameObject.tag == "ball" && IsFirst)
        {
            IsFirst = true;
            Dialogue.instance.StartDialogue(d);
            IsFirst = false;
        }
        else if (this.gameObject.tag == "Gate" && collision.gameObject.tag == "ball" && !Player.Instance.haveKey)
        {
            Dialogue.instance.StartDialogue(d);
        }
    }
}
