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
    private ARManager ProgramManagerScript;

    void Start()
    {
        ProgramManagerScript = FindObjectOfType<ARManager>();
    }

    public void RestartScene()
    {
        //PhotonNetwork.LoadLevel(2); TODO
        Spawn();
        dieText = GameObject.Find("DieScreen(Clone)");
        restartButton = this.gameObject;
        Destroy(dieText);
        Destroy(restartButton);
    }

    public void Spawn()
    {
        ProgramManagerScript.ChooseObject = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
