using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trambulin : MonoBehaviour
{
    public float UpForce;

    private void Start()
    {
        UpForce = 5f;
    }

    private void Update()
    {
        if (Player.Instance.touchGround) UpForce = 5f;
        if (UpForce > 30f) UpForce = 30f;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "rugo")
        {
            Player.Instance.myBody.velocity = new Vector3(0, UpForce, 0);
            UpForce += 5f;
        }
       
    }
}
