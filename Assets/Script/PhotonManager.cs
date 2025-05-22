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


    public Slider maxPlayerSlider;
    public InputField maxPlayerText; // (or TMP_Text if you're using TextMeshPro)

    private const int MinNumber = 2;

  

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(this);
    }
    private void Update()
    {
        OnSliderValueChanged(maxPlayerSlider.value);
    }

    private void Start()
    {
        maxPlayerSlider.minValue = MinNumber;
        maxPlayerSlider.maxValue = 10;
    }
    public void OnSliderValueChanged(float value)
    {
        int playerCount = Mathf.RoundToInt(value);
        maxPlayerText.text = playerCount.ToString();
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

        int maxPlayers = Mathf.RoundToInt(maxPlayerSlider.value);

        RoomOptions roomOptions = new RoomOptions()
        {
            MaxPlayers = (byte)maxPlayers,
            IsOpen = true,
            IsVisible = true
        };
        Debug.Log("Join max Players : " + maxPlayers);
        PhotonNetwork.CreateRoom(CreateRoomInput.text, roomOptions, TypedLobby.Default);   
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

    public void JoinRoom()
    {
        Debug.Log("Trying to join my Custom Room.....");
        PhotonNetwork.JoinRoom(JoinRoomInput.text);
    }

    public void JoinRoomList(string RoomName)
    {
        PhotonNetwork.JoinRoom(RoomName);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("< color = green > Join room  successfully.... </ color >");
        currentRoomName = PhotonNetwork.CurrentRoom.Name;
        Debug.Log("Number of Players : "+PhotonNetwork.CountOfPlayersInRooms);
        PhotonNetwork.LoadLevel(1);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
        Debug.Log("<color=red> Join room  Failed.... </color>");
    }

    
}

