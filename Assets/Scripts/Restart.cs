using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class Restart : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    GameObject dieText;
    GameObject restartButton;

    void Start()
    {
        
    }

    public void RestartScene()
    {
        //PhotonNetwork.LoadLevel(2);
        PhotonNetwork.Instantiate(player.name, new Vector3(Random.Range(-45, 45), 3, Random.Range(-45, 45)), Quaternion.identity);
        dieText = GameObject.Find("DieScreen(Clone)");
        restartButton = this.gameObject;
        Destroy(dieText);
        Destroy(restartButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
