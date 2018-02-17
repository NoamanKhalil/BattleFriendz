using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;

public class FlipCs : PunBehaviour
{
   public float speed;
    public float AngleToFlip;


    void Update()
    {
        if (!photonView.isMine)
        {
            return;
        }
        float step = speed * Time.deltaTime; 

        if (Input.GetKeyDown(KeyCode.E))
        {
            //rotate player to 90 degrees clockwise based on a new vector , eulerangles would move player in degreees 
            //transform.rotation = Quaternion.Lerp(from.rotation, to.rotation, Time.time * speed);
            Quaternion r = Quaternion.Euler(0, AngleToFlip, 0);
            transform.rotation *= r;
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            //rotate player to 90 degrees clockwise based on a new vector , eulerangles would move player in degreees 
            Quaternion r = Quaternion.Euler(0, -AngleToFlip, 0);
            transform.rotation *= r;
        }
    }
}