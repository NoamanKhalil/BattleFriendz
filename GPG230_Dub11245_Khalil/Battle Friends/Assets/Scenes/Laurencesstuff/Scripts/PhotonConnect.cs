using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using UnityEngine.UI;

public class PhotonConnect : PunBehaviour {

    //nneded to connect to photon using version
    const string VERSION = "v0.0.1";
    //specifying room optioins
    RoomOptions myroom;
    public Text RoomNameText;
    public Button connectButton;
    private bool connected = false;
    public GameObject canvas1, canvas2, levelPicker;
    public string LoadingLevel;

	// Use this for initialization
	void Start ()
    {  //connects using this version
        PhotonNetwork.ConnectUsingSettings(VERSION);
        //all players will load the same scene
        PhotonNetwork.automaticallySyncScene = true;
        //connect button interactibal if not connected to photon
        connectButton.interactable = false;
        //setting the options of room
        myroom = new RoomOptions() { isVisible = true, maxPlayers = 2 };
        canvas1.SetActive(true);
        canvas2.SetActive(false);
        levelPicker.SetActive(false);
        LoadingLevel = "Death Match";
    }
	
	// Update is called once per frame
	void Update ()
    {  //if not connected photon button = useless
		if (!PhotonNetwork.connected)
        {
            Debug.Log("connecting");
            connectButton.interactable = false;
        }
        //if connected photon button = useful
        else
        {
            Debug.Log("connected");
            connectButton.interactable = true;
        }
	}

    public void ConnecToRoom()
    {
        //specifying with a name of creating or joining a room 
        PhotonNetwork.JoinOrCreateRoom(RoomNameText.text, myroom, TypedLobby.Default);

        Debug.Log("");
    }
    public override void OnPhotonPlayerConnected(PhotonPlayer newPlayer)
    {
        //if the room is full master cliet will close room & scene will load
        if(PhotonNetwork.playerList.Length == myroom.maxPlayers && PhotonNetwork.isMasterClient)
        {
           
           canvas2.SetActive(false);
           PhotonNetwork.room.IsOpen = false;
           PhotonNetwork.LoadLevel(LoadingLevel);
            
            
            
        }
    }

    public void ConnetToLobby()
    {
        if (PhotonNetwork.connected)
        {
            PhotonNetwork.JoinLobby();
            canvas2.SetActive(true);
            canvas1.SetActive(false);
            levelPicker.SetActive(true);
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings(VERSION);
        }
    }

    public void PickLVL1()
    {
        
            LoadingLevel = "Death Match";
        
    }

    public void PickLVL2()
    {
       
            LoadingLevel = "Death Match 3";
        
    }

    public void PickLVL3()
    {
       
            LoadingLevel = "Death Match Last Map";
      
    }

    public void DisconnectGame()
    {
        PhotonNetwork.Disconnect();
        Application.LoadLevel("MainMenu");
    }
   
}


