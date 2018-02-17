using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorrentCs : MonoBehaviour
{
    public Transform[] patrolPos;
    // speed of patrolling
    public float moveSpeed;
    //minimum distance before player mvoes to next patrol point
    public float reachDist; 
    public float gizmosRadius;
    public bool canPatrol;
    public Transform firepos;
    public GameObject projectile;
    public float fireBreak;
    public int shotsToDie;

    private float tempFireBreak;
    private int currentPoint = 0; 
    // Use this for initialization
    void Start ()
    {
        tempFireBreak = fireBreak;	
	}
    public void takeDamage()
    {
        shotsToDie--;
    }
	// Update is called once per frame
	void Update ()
    {
        if (shotsToDie <= 0)
        {
            Destroy(this.gameObject);
        }
        fireBreak -= Time.deltaTime;
        //Debug.Log(fireBreak);
        if (fireBreak <= 0)
        {
            GameObject bullet = Instantiate(projectile, firepos.position, Quaternion.AngleAxis(0, Vector3.right)) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(firepos.forward * 1000);
            fireBreak = tempFireBreak;
        }
        if (canPatrol == true)
        {
            patrol();
        }
    }

    void patrol()
    {
        float dist = Vector3.Distance(patrolPos[currentPoint].position, transform.position);

        transform.position = Vector3.MoveTowards(transform.position, patrolPos[currentPoint].position, Time.deltaTime * moveSpeed);

        if (dist <= reachDist)
        {
            currentPoint++;
        }
        if (currentPoint >= patrolPos.Length)
        {
            currentPoint = 0; 
        }
    }

    private void OnDrawGizmos()
    {
        if (patrolPos.Length > 0)
        {
            for (int i = 0; i < patrolPos.Length; i++)
            {
               if (patrolPos == null)
                {
                    Gizmos.DrawSphere(patrolPos[i].position, gizmosRadius);
                }
               
                
            }
        }
    }
}
