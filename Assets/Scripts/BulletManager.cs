using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BulletManager : MonoBehaviour
{
    public float BulletDmg = 10;
    PhotonView view;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    [PunRPC]
    private void OnCollisionEnter(Collision collision)
    {
        GameObject col = collision.gameObject;
        TankManager CheckTank = col.GetComponent<TankManager>();
        if (CheckTank != null)
        {
            CheckTank.CurrentHP -= BulletDmg;
            Debug.Log(CheckTank.CurrentHP.ToString());
            Destroy(this.gameObject);
            //PhotonNetwork.Destroy(this.gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
