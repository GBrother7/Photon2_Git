using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomList : MonoBehaviourPunCallbacks
{
    public GameObject RoomPrefab;
    public Transform Contant;

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        for (int i = 0; i < roomList.Count; i++)
        {
            GameObject Room = Instantiate(RoomPrefab, Vector3.zero, Quaternion.identity, Contant.transform);
            Room.GetComponent<Room>().Name.text = roomList[i].Name;
        }
    }

}
