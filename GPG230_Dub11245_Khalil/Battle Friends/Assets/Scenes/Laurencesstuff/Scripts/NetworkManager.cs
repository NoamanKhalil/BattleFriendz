using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;

public class NetworkManager : PunBehaviour {

    public GameObject[] SpawnPoints;
    public string[] Players;
    private string player1 , player2;
    public GameObject[] playerz;
    bool is2players;


    private void Awake()
    {
        //instatioating player gameobjects with strings 
        PlayerPrefs.SetString("player1", "Player11");
        PlayerPrefs.SetString("player2", "Player11");
    }
	// Use this for initialization
	void Start ()
    {
        player1 = PlayerPrefs.GetString("player1");
        player2 = PlayerPrefs.GetString("player2");
        Players[0] = PlayerPrefs.GetString("player1");
        Players[1] = PlayerPrefs.GetString("player2");
        //each player has own Photon ID, and it will each have its own spawn point
        PhotonNetwork.Instantiate(Players[PhotonNetwork.player.ID - 1], SpawnPoints[PhotonNetwork.player.ID - 1].transform.position, Quaternion.identity, 0);

        

       // Invoke("makebooltru", 2f);
    }

  

    // Update is called once per frame
    void Update ()
    {
        Invoke("makebooltru", 2f);
        //  if (is2players == true)
        //  {
        if (playerz.Length == 1)
        {
            PhotonNetwork.Disconnect();
            Application.LoadLevel("Win Screen");
        }
      //  }
        
		
	}

    void makebooltru()
    {
      //  is2players = true;
        playerz = GameObject.FindGameObjectsWithTag("Player");
    }
}
