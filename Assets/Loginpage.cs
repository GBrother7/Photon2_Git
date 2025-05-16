using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loginpage : MonoBehaviour
{
     [SerializeField] private Button playBtn;

     private UIManager uiManager;
    void Start()
    {
        uiManager = transform.root.GetComponent<UIManager>();
        playBtn.onClick.AddListener(ConnectToServer);
    }

    private void OnEnable()
    {
        PhotonManager.OnConnectToServer += OpenHome;
    }

    private void OnDisable()
    {
        PhotonManager.OnConnectToServer -= OpenHome;
    }

    private void OpenHome()
    {
        uiManager.ShowPanel(2);
    }

    private void ConnectToServer()
    {
        PhotonManager.Instance.ConnectToServer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
