using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Transform door;
    public Vector3 endpos;
    public Vector3 startpos;
    public Rigidbody2D doorBody;


    void Start()
    {
        startpos = transform.position;
        endpos = transform.position;
        endpos.y = startpos.y-2;
        doorBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
       OpenAndClose();
    }

    private void OpenAndClose()
    {
        //opening
        if (buttoncollider.instance.DoorShouldMove)
        {
            StartCoroutine(Move(this.gameObject, endpos, 0.03f));
        }
        //closing
        if (!buttoncollider.instance.DoorShouldMove && this.gameObject.name != "door_level5")
        {
            StartCoroutine(Move(this.gameObject, startpos, 0.03f));
        }
        else if (!buttoncollider.instance.DoorShouldMove && this.gameObject.name == "door_level5")
        {
            StartCoroutine(Move(this.gameObject, startpos, 0.007f));
        }
    }

  public IEnumerator Move(GameObject obj, Vector3 end, float speed)
    {
        while (obj.transform.position != end)
        {
            obj.transform.position = Vector3.MoveTowards(obj.transform.position, end, speed * Time.fixedDeltaTime);
            yield return null;
        }
    }
}
