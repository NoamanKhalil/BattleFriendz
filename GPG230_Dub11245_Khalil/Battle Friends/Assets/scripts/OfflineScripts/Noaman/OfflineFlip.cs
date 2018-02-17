using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfflineFlip : MonoBehaviour
{
    private static FlipCs cs;

    void Awake()
    {

    }

    public float AngleToFlip;
    //IEnumerator FlipMe(Vector3 byAngles, float inTime)
    //{
    //	var fromAngle = transform.rotation;
    //	var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
    //	for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
    //	{
    //		transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
    //		yield return null;
    //	}
    // }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //rotate player to 90 degrees clockwise based on a new vector , eulerangles would move player in degreees 
            transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y + AngleToFlip, 0));
            //StartCoroutine(FlipMe(Vector3.up* -90, 0.8f));
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            //rotate player to 90 degrees clockwise based on a new vector , eulerangles would move player in degreees 
            transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y - AngleToFlip, 0));
            //StartCoroutine(FlipMe(Vector3.up* 90, 0.8f));
        }

    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 direction = transform.TransformDirection(Vector3.forward) * 5;
        Gizmos.DrawRay(transform.position, direction);
    }


}
