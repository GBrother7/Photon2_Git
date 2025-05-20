using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomRoom_Page : MonoBehaviour
{
    

    [SerializeField] private Button CreateRoom_Btn;
    [SerializeField] private Button JoinRoom_Btn;


    private void Start()
    {
        CreateRoom_Btn.GetComponent<Button>().onClick.AddListener(CustomRoomOpen);
        JoinRoom_Btn.GetComponent<Button>().onClick.AddListener(JoinCustomRoom);

    }

    public void CustomRoomOpen()
    {
        PhotonManager.Instance.CreateRoom();
    }

    public void JoinCustomRoom()
    {
        PhotonManager.Instance.JoinRoom();
    }
}
