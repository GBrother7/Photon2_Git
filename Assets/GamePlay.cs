using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("I Have joined "+ PhotonManager.Instance.currentRoomName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
