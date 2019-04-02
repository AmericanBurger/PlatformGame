using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtwarcieDrzwi : MonoBehaviour
{
    public Transform drzwi = null;
    public Transform Monetka;
    public Transform Gracz = null;

    public bool otwarte = false;

    void Update()
    {
        if (otwarte)
        {
            drzwi.position = new Vector3(drzwi.position.x, 3, drzwi.position.z);
        }
        else
        {
            drzwi.position = new Vector3(drzwi.position.x, 1, drzwi.position.z);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
                otwarte = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        otwarte = false;
    }
}