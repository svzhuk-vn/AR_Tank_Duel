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
        GameObject Shell = PhotonNetwork.Instantiate("Shell", SpawnPoint, SpawnRoot) as GameObject; // FIX : PhotonNetwork.Instantiate("Shell") - ???? ????? ??? ????
        Rigidbody Shoot = Shell.GetComponent<Rigidbody>();
        Shoot.AddForce(Shell.transform.forward * firePower, ForceMode.Impulse);
        StartCoroutine(WaitAndDestroy(5,Shell)); // FIX : ???????? ???????? ???? ????? 5 ??????. PhotonNetwork.Destroy(Shell) ??????? ???? ?????????
    }

    IEnumerator WaitAndDestroy(float time, GameObject bullet)
    {
        yield return new WaitForSeconds(time);
        PhotonNetwork.Destroy(bullet);
    }
}
