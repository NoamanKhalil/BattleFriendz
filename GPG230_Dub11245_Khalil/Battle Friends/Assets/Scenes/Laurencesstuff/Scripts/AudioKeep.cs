using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioKeep : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        if (GameObject.Find("Carlos is bae") == null)
        {
            transform.name = "Carlos is bae";
            DontDestroyOnLoad(gameObject);

        }
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (SceneManager.GetActiveScene().name == "Connecting")
        {
            Destroy(gameObject);
        }
        if (SceneManager.GetActiveScene().name == "Tutorial Scene")
        {
            Destroy(gameObject);
        }
    }
    
}
