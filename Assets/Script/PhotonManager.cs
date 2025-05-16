using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    void Start()
    {
        Debug.Log("Connecting to server");
        PhotonNetwork.ConnectUsingSettings();
    }


    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("<color=green>Connected to server.... </color>");
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
        CreateRoom();
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


}
