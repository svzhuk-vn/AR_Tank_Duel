using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Mover : MonoBehaviour
{
    private Joystick joystick;
    private Rigidbody rigidbody;
    private float moveSpeed = 10;
    PhotonView view;
    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        rigidbody = GetComponent<Rigidbody>();
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (view.IsMine) //управление только локальным(!) игроком  
        {
            rigidbody.velocity = new Vector3(joystick.Horizontal * moveSpeed, rigidbody.velocity.y, joystick.Vertical * moveSpeed);
            if (joystick.Horizontal != 0 || joystick.Vertical != 0) transform.rotation = Quaternion.LookRotation(rigidbody.velocity);
        }
    }
}
