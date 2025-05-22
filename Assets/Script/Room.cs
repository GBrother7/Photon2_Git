using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Room : MonoBehaviour
{
    public Text Name;
    
    public void JoinRoom()
    {
        PhotonManager.Instance.JoinRoomList(Name.text);
    }
}
  