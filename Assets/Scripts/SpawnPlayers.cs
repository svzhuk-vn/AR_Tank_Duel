using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.Instantiate(player.name, new Vector3(Random.Range(-45, 45), 3, Random.Range(-45, 45)), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
