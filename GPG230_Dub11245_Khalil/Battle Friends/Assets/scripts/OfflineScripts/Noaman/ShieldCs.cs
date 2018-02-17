using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCs : MonoBehaviour {


    public Gradient shieldGradiant;

    public float shield;
    public float damageToTake;

    private Renderer ren;
    // Use this for initialization
    void Start()
    {
        ren = GetComponent<Renderer>();
        //ren.material.color = startColor;
    }
    // Update is called once per frame
    void Update()
    {
        ren.material.color = shieldGradiant.Evaluate(shield/ 10);
        if (shield <= 0)
        {
            //GetComponent<Renderer>().enabled = false;
            //  GetComponent<Collider>().enabled = false;
            if (shield <= 0)
            {
                this.GetComponent<Collider>().enabled = false;
            }
            else
            {
                this.GetComponent<Collider>().enabled = true;
            }
           

        }
        Invoke("regenShield", 10f);
    }
    public void removeShield()
    {
        shield -= damageToTake;

    }
    public void regenShield()
    {
        shield += 1;
    }

}
