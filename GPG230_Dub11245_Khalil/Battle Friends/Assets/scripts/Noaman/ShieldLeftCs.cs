using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldLeftCs : MonoBehaviour
{
    public Gradient leftShieldGradiant;
    //public Color startColor;
   // public Color endColor;

    public float shieldLeft;
    public float damageToTake;

    private Renderer ren;
    // Use this for initialization
    void Start ()
    {
        ren = GetComponent<Renderer>();
      //  ren.material.color = startColor;
    }
	
	// Update is called once per frame
	void Update ()
    {
      //  ren.material.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time, 1));
      ren.material.color = leftShieldGradiant.Evaluate(shieldLeft/10);
        if (shieldLeft <= 0)
        {
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
        }
    }
   public void removeLeftShield()
    {
        shieldLeft-=damageToTake;

    }
}
