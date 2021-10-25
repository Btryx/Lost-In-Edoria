using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour { 

    private Transform player;
    private Vector3 CamPos;


    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
;
    }

    // Update is called once per frame
    void Update()
    {
        if (player) {

            CamPos = transform.position;
            CamPos.x = player.position.x;
            CamPos.y = player.position.y;
            transform.position = CamPos;
        }        
    }
}
