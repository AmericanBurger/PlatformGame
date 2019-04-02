using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera2 : MonoBehaviour {
    public Transform Kamera = null;

    public Camera firstPersonCamera;
    public Camera overheadCamera;

    public void ShowOverheadView()
    {
        firstPersonCamera.enabled = false;
        overheadCamera.enabled = true;
    }

    public void ShowFirstPersonView()
    {
        firstPersonCamera.enabled = true;
        overheadCamera.enabled = false;
    }




// Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Kamera.position = new Vector3(9, 5, -3);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Kamera.position = new Vector3(15, 5, -3);
        }
    }
}
