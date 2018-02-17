using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingeControlCs : MonoBehaviour
{
    public float minimumDistCheck;
    Vector3 look;
    private Quaternion parentRotationOffset = Quaternion.identity;
    private float angle;
    private float mouse2gunPos;

    void Update()
    {
        rotate  ();
    }
    void rotate()
    {

        look = Input.mousePosition;
        look.z = Mathf.Abs(Camera.main.transform.position.y - transform.position.y);
        look = Camera.main.ScreenToWorldPoint(look);
       //tramsorm.roation= Quaternion.Look(look)//wrong line /// the right one is below
        transform.LookAt(look);//* parentRotationOffset;
        // adijsut angel from 30> < 180
            if (Mathf.Abs(transform.localRotation.eulerAngles.y) > 30&& Mathf.Abs(transform.localRotation.eulerAngles.y) <=180 )
            {
            //Vector3 tempRotation = transform.localRotation.eulerAngles;
            transform.localRotation = Quaternion.Euler(0,30,0);
            }
            //adjust between  180 ><330
            else if (Mathf.Abs(transform.localRotation.eulerAngles.y) < 330  && Mathf.Abs(transform.localRotation.eulerAngles.y)>180 )
            {
           // Vector3 tempRotation = transform.localRotation.eulerAngles;
            transform.localRotation = Quaternion.Euler(0,-30, 0);
             }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(look, 0.5f);

       // Gizmos.DrawSphere(transform.position, minimumDistCheck);
    }


}
