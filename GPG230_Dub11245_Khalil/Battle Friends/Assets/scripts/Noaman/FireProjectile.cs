using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    public GameObject projectile;
	public Transform firePos;
	// Update is called once per frame

    

	void Update () 
	{
		if (Input.GetKey(KeyCode.Mouse0))
	     {
			GameObject bullet = Instantiate(projectile, firePos.position, Quaternion.identity) as GameObject;
			bullet.GetComponent<Rigidbody>().AddForce(firePos.forward* 1000);
         }	



	}

	void rotate()
	{
		Vector3 look = Input.mousePosition;
		look.z = Mathf.Abs(Camera.main.transform.position.y - transform.position.y);
		look = Camera.main.ScreenToWorldPoint(look);
		transform.LookAt(look);

   }

}
