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
    public GameObject restartButton;
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
        if (PV.IsMine) hp.text = "HP: " + CurrentHP.ToString() + " / " + MaxHP.ToString(); // FIX : отображение хп для каждого игрока отдельно 
        if (PV.IsMine && CurrentHP == 0) // FIX2 : удаление проигравшего с экрана обоих игроков
        {
            Instantiate(dieText, GameObject.Find("Canvas").transform); // экран смерти
            Instantiate(restartButton, GameObject.Find("Canvas").transform); // кнопка перезагрузки
            PhotonNetwork.Destroy(this.gameObject); // FIX : удаление проигравшего с экрана обоих игроков
            }
        }




    }
