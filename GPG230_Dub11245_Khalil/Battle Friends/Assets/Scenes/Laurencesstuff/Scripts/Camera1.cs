using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;

public class Camera1 : PunBehaviour {

    private GameObject player;

    private GameObject SceneCamera;

    private Vector3 offset;

    // Use this for initialization
    void Start ()
    {
        SceneCamera = GameObject.FindGameObjectWithTag("MainCamera");

        player = gameObject;
        
        offset = transform.position - player.transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!photonView.isMine)
        {
            return;
        }
        else
        {
           offset.Set(0, 15, 0);
          
           SceneCamera.transform.position = player.transform.position + offset;
        }
    }
}
