using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomePage : MonoBehaviour
{
    [SerializeField] private Button playRandom;
    [SerializeField] private Button playFriends;

    private UIManager uimanager;

    // Start is called before the first frame update
    void Start()
    {
        playRandom.onClick.AddListener(PlayRandom);
        playFriends.onClick.AddListener(PlayWithFriends);

        uimanager = transform.root.GetComponent<UIManager>();
    }

   
    private void PlayRandom()
    {
        PhotonManager.Instance.CreateORjoinRandom();
    }

    private void PlayWithFriends()
    {
        uimanager.ShowPanel(3);
    }
}
