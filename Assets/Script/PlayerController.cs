using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private PhotonView photonView;
    public GameObject Mark;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (!photonView.IsMine) return;
        {
            Vector3 moveDirection = Vector3.zero;

            // Left
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection.x = -1;
                transform.rotation = Quaternion.Euler(0, 0, 0); // Face Left (no flip)
            }

            // Right
            else if (Input.GetKey(KeyCode.D))
            {
                moveDirection.x = 1;
                transform.rotation = Quaternion.Euler(0, 180, 0); // Face Right (flip on Y)
            }

            // Up
            if (Input.GetKey(KeyCode.W))
            {
                moveDirection.y = 1;
            }

            // Down
            if (Input.GetKey(KeyCode.S))
            {
                moveDirection.y = -1;
            }

            // Normalize and move
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
    }  
}
