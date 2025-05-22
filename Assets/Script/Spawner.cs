using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = PhotonNetwork.Instantiate("Player", new Vector3(Random.Range(-2.42f, 2.42f), Random.Range(6.2f, -4.2f), 0f), Quaternion.identity);
        player.GetComponent<PlayerController>().Mark.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
