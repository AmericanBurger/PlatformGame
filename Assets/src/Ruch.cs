using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ruch : MonoBehaviour {
    public bool naZiemi = false;
    public int punkty = 0;
    public Text text_Punkty = null;
    public float rotationSpeed = 10f;
    private AudioSource sfx = null;

	// Use this for initialization
	void Start() {
        sfx = GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void Update() {
        text_Punkty.text = punkty.ToString();

        Vector3 tempVelocity = gameObject.GetComponent<CharacterController>().velocity;

        if (naZiemi == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                tempVelocity += Vector3.up * 6.0f; //(0, 6, 0)
            }
        }
        if (naZiemi == false)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                tempVelocity += Vector3.right * -0.1f; //(0, 6, 0)
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                tempVelocity += Vector3.right * 0.1f; //(0, 6, 0)
            }
        }

        Vector2 temp = new Vector2(tempVelocity.x, tempVelocity.z);

        /*if (temp.magnitude < 4f)
        {
            if (Input.GetKey(KeyCode.W))
            {
                tempVelocity += transform.forward;
            }
            else if (Input.GetKey(KeyCode.S))
                tempVelocity -= transform.forward;
        }*/
        
        /*if (temp.magnitude < 4f)
        {
            if (Input.GetKey(KeyCode.D))
            {
                tempVelocity += transform.right;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                tempVelocity -= transform.right;
            }
            else
            {
                tempVelocity += transform.forward * 0f;
            }
        }*/
        
        if (Input.GetKey(KeyCode.W))
        {
            tempVelocity += transform.forward * 0.15f; //(0, 0, 1)
        }
        else if(Input.GetKey(KeyCode.S))
        {
            tempVelocity += transform.forward * -0.15f;
        }
        else
        {
            tempVelocity += transform.forward * 0f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, -rotationSpeed, 0f);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, rotationSpeed, 0f);
        }
        //CharacterController controller = GetComponent<CharacterController>();
        /*Vector3 horizontalVelocity = controller.velocity;
        horizontalVelocity = new Vector3(controller.velocity.x, 0, controller.velocity.z);
        float horizontalSpeed = horizontalVelocity.magnitude;
        float verticalSpeed = controller.velocity.y;
        float overallSpeed = controller.velocity.magnitude;*/

        tempVelocity = gameObject.GetComponent<CharacterController>().velocity;
    }

    void OnCollisionEnter(Collision Other)
    {
        if(Other.gameObject.tag == "ziemia" || Other.gameObject.tag == "penkajonce")
        {
            naZiemi = true;
            if(Other.gameObject.tag == "penkajonce")
            {
                Destroy(Other.gameObject, 2);
            }
        }
    }
    void OnCollisionStay(Collision Other)
    {
        if (Other.gameObject.tag == "ziemia" || Other.gameObject.tag == "penkajonce")
        {
            naZiemi = true;
        }
    }
    void OnCollisionExit(Collision Other)
    {
        if (Other.gameObject.tag == "ziemia" || Other.gameObject.tag == "penkajonce")
        {
            naZiemi = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Monetka")
        {
            sfx.PlayOneShot(sfx.clip);
            Destroy(other.gameObject);
            ++punkty;
        }
    }
}
