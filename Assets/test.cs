using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class test : MonoBehaviour
{
    [SerializeField] private float _playerHP = 100;
    PhotonView PV;
    public Text showHP;

    private void Start()
    {
        PV = GetComponent<PhotonView>();
        showHP = GameObject.Find("HPText").GetComponent<Text>();
    }
    private float playerHP
    {
        get => _playerHP;
        set
        {
            _playerHP = value;
            showHP.text = playerHP.ToString();

            if (PV.IsMine)
            {
                // sync the change to others
                PV.RPC(nameof(RemoteSetHP), RpcTarget.Others, _playerHP);
            }
        }
    }

    [PunRPC]
    void RemoteSetHP(float hp)
    {
        // this executes the setter on all remote players
        // and thus automatically also updates the display
        playerHP = hp;
    }
}
