using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestrucktableCs : MonoBehaviour
{
    public Color startColor;
    public Color endColor; 
    public int shotsToDestroy;

    private Material thisMaterial;

	// Use this for initialization
	void Start ()
    {
        thisMaterial = GetComponent<Material>(); 
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(shotsToDestroy <=0 )
        {
            Destroy(this.gameObject);
        }
	}

    public void subtractShots()
    {
        shotsToDestroy--; 
    }
}
