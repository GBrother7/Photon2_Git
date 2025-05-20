using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System;

public class PhotonManager : MonoBehaviourPunCallbacks
{
     public InputField CreateRoomInput;
     public InputField JoinRoomInput;

    public static PhotonManager Instance;

    public static Action OnConnectToServer;
    public static Action CreateCustomRoom;


    public string currentRoomName;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(this);
    }

    void Start()
    {
     
    }


    public void ConnectToServer()
    {
        Debug.Log("Connecting to server");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("<color=green>Connected to server.... </color>");
        OnConnectToServer?.Invoke();
        JoinLobby();

    }

    private void JoinLobby()
    {
        Debug.Log("Trying to join lobby");
        PhotonNetwork.JoinLobby();
    }


    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.Log("<color=green> Joined lobby successfully.... </color>");      
    }

    public void CreateRoom()
    {
        Debug.Log("Trying to create room");
        PhotonNetwork.CreateRoom(CreateRoomInput.text);
    }

    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        Debug.Log("<color=green> Created room  successfully.... </color>");
       // PhotonNetwork.LoadLevel(1);
    }


    public void CreateORjoinRandom()
    {
        PhotonNetwork.JoinRandomOrCreateRoom();
        Debug.Log("Trying to join random room");
    }

    public void JoinRoom()
    {
        Debug.Log("Trying to join my Custom Room.....");
        PhotonNetwork.JoinRoom(JoinRoomInput.text);
       
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("< color = green > Join room  successfully.... </ color >");
        currentRoomName = PhotonNetwork.CurrentRoom.Name;
        PhotonNetwork.LoadLevel(1);
    }

    
}

