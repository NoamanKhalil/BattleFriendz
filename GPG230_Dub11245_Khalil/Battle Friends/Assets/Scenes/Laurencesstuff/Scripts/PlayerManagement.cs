using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagement : MonoBehaviour {

    public GameObject btnLoggin;
    public GameObject btnRegister;

	// Use this for initialization
	void Start ()
    {
        btnLoggin.SetActive(false);
        btnRegister.SetActive(false);

	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    public void Dologin()
        {
            btnLoggin.SetActive(true);
            btnRegister.SetActive(false);
        }
    public void DoRegister()
    {
        btnRegister.SetActive(true);
        btnLoggin.SetActive(false);
    }
}