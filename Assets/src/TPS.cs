using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPS : MonoBehaviour {
    public Transform player = null;
    public float where = 2f;

    [Header("Oddalenie kamery")]
    public float currentOddalenie = 1f;
    public float minOddalenie = 1f;
    public float maxOddalenie = 2f;
	
    //void Start () {
		
	//}

	void Update ()
    {
        //kamera nad graczem
        transform.position = player.position + Vector3.up * 1f; //1f
        //kamera nad graczem lekko za nim
        transform.position += -player.forward * currentOddalenie;
        //patrzenie w kierunku gdzie patrzy gracz
        //transform.LookAt(player.position + player.forward * where);

        Vector3 playerVel = player.GetComponent<Rigidbody>().velocity;
        Vector2 temp = new Vector2(playerVel.x, playerVel.z);
        float vel = temp.magnitude;

        currentOddalenie = Mathf.Lerp(minOddalenie, maxOddalenie, vel / 10f);

        if(Input.GetAxis("Mouse X") != 0f)
        {
            float rotationSpeed = player.GetComponent<SimpleCharacterControl>().rotationSpeed;

            player.Rotate(0f, rotationSpeed * Input.GetAxis("Mouse X"), 0f);
        }
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, player.eulerAngles.y, player.eulerAngles.z);

        if (Input.GetAxis("Mouse Y") != 0f)
        {
            float rotationSpeed = player.GetComponent<SimpleCharacterControl>().rotationSpeed;
            if(transform.eulerAngles.x >= -90 && transform.eulerAngles.x <= 90)
            {
                transform.Rotate(Input.GetAxis("Mouse Y") * -rotationSpeed, 0f, 0f);
            }
            else
            {
                if(transform.eulerAngles.x >= -90)
                {
                    transform.rotation = Quaternion.Euler(-90, player.eulerAngles.y, player.eulerAngles.z);
                }
                else if(transform.eulerAngles.x <= 90)
                {
                    transform.rotation = Quaternion.Euler(90, player.eulerAngles.y, player.eulerAngles.z);
                }
            }
            //transform.Rotate(Input.GetAxis("Mouse Y"), 0f, 0f);
        }

    }
}
