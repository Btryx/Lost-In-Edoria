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

    private void Update()
    {
       OpenAndClose();
    }

    private void OpenAndClose()
    {
        //opening
        if (buttoncollider.instance.DoorShouldMove)
        {
            StartCoroutine(Move(this.gameObject, endpos, 0.008f));
        }
        //closing
        if (buttoncollider.instance.DoorShouldMove == false)
        {
            StartCoroutine(Move(this.gameObject, startpos, 0.003f));
        }
    }

  public IEnumerator Move(GameObject obj, Vector3 end, float speed)
    {
        while (obj.transform.position != end)
        {
            obj.transform.position = Vector3.MoveTowards(obj.transform.position, end, speed * Time.deltaTime);
            yield return null;
        }
    }
}
