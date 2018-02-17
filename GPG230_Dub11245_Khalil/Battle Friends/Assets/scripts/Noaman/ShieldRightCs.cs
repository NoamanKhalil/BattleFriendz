using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldRightCs : MonoBehaviour
{
    public Gradient rightShieldGradiant;

    public float shieldRight;
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
        ren.material.color = rightShieldGradiant.Evaluate(shieldRight/10);
        if (shieldRight <= 0)
        {
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
        }
    }
    public void removeRightShield()
    {
        shieldRight-=damageToTake;

    }

}
