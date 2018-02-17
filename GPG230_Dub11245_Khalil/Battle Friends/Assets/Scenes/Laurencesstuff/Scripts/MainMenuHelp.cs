using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuHelp : MonoBehaviour {

    public GameObject Helpcenter;

	// Use this for initialization
	void Start ()
    {
        Helpcenter.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void openHelp()
    {
        Helpcenter.SetActive(true);
    }
}
