using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

    public bool ThirdPersonViewFlag;

	// Use this for initialization
	void Start () {
	    if(ThirdPersonViewFlag)
        {
            GameObject subCamera = GameObject.FindGameObjectWithTag("SubCamera");
            subCamera.GetComponentInChildren<Camera>().enabled = true;
            
            GameObject mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
            mainCamera.GetComponentInChildren<Camera>().enabled = false;
            subCamera.tag = "MainCamera";
            mainCamera.tag = "SubCamera";
        }
        else
        {
            GameObject subCamera = GameObject.FindGameObjectWithTag("SubCamera");
            subCamera.GetComponentInChildren<Camera>().enabled = false;
            GameObject mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
            mainCamera.GetComponentInChildren<Camera>().enabled = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
