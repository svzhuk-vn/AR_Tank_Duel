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
    PhotonView PV;


    // Start is called before the first frame update
    void Start()
    {
        
        PV = GetComponent<PhotonView>();
        hp = GameObject.Find("HPText").GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PV.IsMine) hp.text = "HP: " + CurrentHP.ToString() + " / " + MaxHP.ToString();
        if (CurrentHP == 0) Destroy(this.gameObject);
    }

    

}
