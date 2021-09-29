using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trambulin : MonoBehaviour
{
    public float UpForce;

    private void Start()
    {
        UpForce = 500f;
    }

    private void Update()
    {
        if (UpForce > 1450 || Player.Instance.touchGround) UpForce = 500;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "rugo" && Player.Instance.touchGround == false)
        {
            Player.Instance.myBody.AddForce(new Vector2(0, UpForce));
            UpForce += 200f;
        }
    }
}
