using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCs : MonoBehaviour
{
	public float timeToDestoryObject;

	// Use this for initialization
	void Start () 
	{
        
	}
	
	// Update is called once per frame
	void Update ()
	{
		timeToDestoryObject -= Time.deltaTime;
		//Debug.Log(timeToDestoryObject);
		if (timeToDestoryObject <=0)
		{
			//Destroy(this.gameObject);
		}
	}
    void OnCollisionEnter(Collision col)
    {

        //Destroy(this.gameObject);

        if (col.gameObject.tag.Equals("obstacle"))
        {
            if (col.gameObject.GetComponent<DestrucktableCs>() != null)
            {
                col.gameObject.GetComponent<DestrucktableCs>().subtractShots();
                Destroy(this.gameObject);
            }
        }
        else if (col.gameObject.tag.Equals("torrent"))
        {
            if (col.gameObject.GetComponent<TorrentCs>() != null)
            {
                col.gameObject.GetComponent<TorrentCs>().takeDamage();
               Destroy(this.gameObject);
            }
        }
        else if (col.gameObject.tag.Equals("Player"))
        {
            if (col.gameObject.GetComponent<PlayerBehaviourScriptCs>() != null)
            {
                col.gameObject.GetComponent<PlayerBehaviourScriptCs>().takeDamage();
                Destroy(this.gameObject);
            }
        }
        else if (col.gameObject.tag.Equals("shield"))
        {
                col.gameObject.GetComponent<ShieldCs>().removeShield();
                Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject, 1.0f);
        }
       
        
    }


}
