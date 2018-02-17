using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <para>MonoBehaviour is the base class from which every Unity script derives.</para>
public class FireProjectileCs : MonoBehaviour
{
    public GameObject projectile;
	public Transform firePos;
	public float fireBreak;
	private float tempfireBreak;

	void Start()
	{
		
	}
	// Update is called once per frame
	void Update () 
	{

		fireBreak -= Time.deltaTime;
		//Debug.Log(fireBreak);
		if (Input.GetKey(KeyCode.Mouse0) && fireBreak <= 0)
	     {
			GameObject bullet = Instantiate(projectile, firePos.position,Quaternion.AngleAxis (90,Vector3.right)) as GameObject;
			bullet.GetComponent<Rigidbody>().AddForce(firePos.forward* 1000);
			fireBreak = 0.5f;  
         }
	
	}


}
