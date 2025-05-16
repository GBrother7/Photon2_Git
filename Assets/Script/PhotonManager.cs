using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    public static PhotonManager Instance;

    public static Action OnConnectToServer;


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

    private void CreateRoom()
    {
        Debug.Log("Trying to create room");
        PhotonNetwork.CreateRoom("Saptarshi");
    }

    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        Debug.Log("<color=green> Created room  successfully.... </color>");
    }


    public void CreateORjoinRandom()
    {
        PhotonNetwork.JoinRandomOrCreateRoom();
        Debug.Log("Trying to join random room");
    }


    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("Joined Room");
        currentRoomName = PhotonNetwork.CurrentRoom.Name;
        PhotonNetwork.LoadLevel(1);

    }


}

