using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingeControl : MonoBehaviour {

    public float angleToTurn;
    bool canRotate = true;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //transform.eulerAngles =new Vector3 (0, Mathf.Clamp(transform.rotation.y , -70,70), 0);
        rotate();
    }
    //void rotate()
    //{
    //	Vector3 look = Input.mousePosition;
    //	look.z = Mathf.Abs(Camera.main.transform.position.y - transform.position.y);
    //	look = Camera.main.ScreenToWorldPoint(look);
    //	//TODO: Clamp gun position to -70,70
    //	transform.LookAt(look);
    //	transform.eulerAngles=new Vector3(0, Mathf.Clamp(transform.eulerAngles.y, -70, 70), 0);

    // }
    void rotate()
    {
        Vector3 look = Input.mousePosition;
        look.z = Mathf.Abs(Camera.main.transform.position.y - transform.position.y);
        look = Camera.main.ScreenToWorldPoint(look);

        // Clamp gun position to -70,70
        float angle = Vector3.Angle(transform.parent.forward, look - transform.position);
        float delta = (angle > angleToTurn) ? (angle - angleToTurn) * Mathf.Sign(look.x * transform.right.x) : 0;
        transform.localRotation = Quaternion.LookRotation(look - transform.position) * Quaternion.Euler(0, -delta, 0);
    }
}
