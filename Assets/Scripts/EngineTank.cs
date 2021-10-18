using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class EngineTank : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject TankTurret;
    [Header("Shooting power")]
    [SerializeField] private int firePower = 1;
    public Button buttonFire;

    public void Start()
    {
        buttonFire = GetComponent<Button>();
        buttonFire.onClick.AddListener(Fire);
    }

    public void Fire()
    {
        TankTurret = GameObject.Find("TurretExit");
        Vector3 SpawnPoint = TankTurret.transform.position;
        Quaternion SpawnRoot = TankTurret.transform.rotation;
        GameObject Shell = PhotonNetwork.Instantiate("Shell", SpawnPoint, SpawnRoot) as GameObject; //PhotonNetwork.Instantiate("Shell") - пули видны для всех
        Rigidbody Shoot = Shell.GetComponent<Rigidbody>();
        Shoot.AddForce(Shell.transform.forward * firePower, ForceMode.Impulse);
        StartCoroutine(WaitAndDestroy(5,Shell)); // корутина удаления пуль после 5 секунд. PhotonNetwork.Destroy(Shell) удаляет пули инстантно
    }

    IEnumerator WaitAndDestroy(float time, GameObject bullet)
    {
        yield return new WaitForSeconds(time);
        PhotonNetwork.Destroy(bullet);
    }
}
