using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomePage : MonoBehaviour
{
    [SerializeField] private Button playRandom;
    [SerializeField] private Button playFriends;


    // Start is called before the first frame update
    void Start()
    {
        playRandom.onClick.AddListener(PlayRandom);
    }

   
    private void PlayRandom()
    {
        PhotonManager.Instance.CreateORjoinRandom();
    }
}
