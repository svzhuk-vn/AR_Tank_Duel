using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARManager : MonoBehaviour
{
    [SerializeField] private GameObject PlaneMarkerPrefab;
    private ARRaycastManager ARRaycastManagerScript;
    public GameObject player;
    public bool ChooseObject;
    GameObject[] ui_objects; 
    GameObject cameraTip; //Tip: move the camera slowly until you see the marker
    GameObject PlayerTip; // Tip: tap on the screen to set the object


    // Start is called before the first frame update
    void Start()
    {
        ARRaycastManagerScript = FindObjectOfType<ARRaycastManager>();
        ChooseObject = true;
        PlaneMarkerPrefab.SetActive(false);
        cameraTip = GameObject.Find("CameraTip");
        cameraTip.SetActive(true);
        PlayerTip = GameObject.Find("PlayerTip");
        PlayerTip.SetActive(false);

        ui_objects = GameObject.FindGameObjectsWithTag("UI");

        foreach (GameObject obj in ui_objects)
        {
            obj.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ChooseObject) ShowMarker();
    }

    void ShowMarker()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        ARRaycastManagerScript.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

       
        

        if (hits.Count > 0)
        {
            PlaneMarkerPrefab.transform.position = hits[0].pose.position;
            PlaneMarkerPrefab.SetActive(true);
            cameraTip.gameObject.SetActive(false);
            PlayerTip.gameObject.SetActive(true);
        }

        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            //PhotonNetwork.Instantiate(player.name, hits[0].pose.position, player.transform.rotation);
            PhotonNetwork.Instantiate(player.name, hits[0].pose.position, Quaternion.identity);
            ChooseObject = false;
            PlaneMarkerPrefab.SetActive(false);
            PlayerTip.gameObject.SetActive(false);


            foreach (GameObject obj in ui_objects)
            {
                obj.SetActive(true);
            }

        }
    }
}
