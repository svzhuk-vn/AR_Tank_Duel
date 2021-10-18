using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class TankManager : MonoBehaviour
{

    public float MaxHP = 100;
    public float CurrentHP = 100;
    public Text hp;
    public GameObject dieText;
    PhotonView PV;


    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        hp = GameObject.Find("HPText").GetComponent<Text>();
        /*dieText = GameObject.Find("DieScreen"); //TODO
        dieText.gameObject.SetActive(false);*/ 
    }

    // Update is called once per frame
    void Update()
    {
        if (PV.IsMine) hp.text = "HP: " + CurrentHP.ToString() + " / " + MaxHP.ToString(); //отображение хп для каждого игрока отдельно 
        if (CurrentHP == 0) PhotonNetwork.Destroy(this.gameObject);
    }




}
