using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasHandler : MonoBehaviour {

    public GameObject img0;
    public GameObject img1;
    public GameObject img2;


	// Use this for initialization
	void Start ()
    {
        img0.SetActive(false);
        img1.SetActive(false);
        img2.SetActive(false);
	}

    void OnTriggerStay(Collider other)
    {
       // Destroy(other.gameObject);
       Debug.Log("Obj works");
        if (other.tag.Equals("Player"))
        {
            if (this.gameObject.tag.Equals("obj0"))
            {
                Debug.Log("Obj works");
                img0.SetActive(true);
            }
            else if (this.gameObject.tag.Equals("obj1"))
            {
                img1.SetActive(true);
            }
            else if (this.gameObject.tag.Equals("obj2"))
            {
                img2.SetActive(true);
            }
        }
        
    }
     void OnTriggerExit(Collider other)
    {
        img0.SetActive(false);
        img1.SetActive(false);
        img2.SetActive(false);
    }
}
