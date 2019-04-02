using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerowanieMonetek : MonoBehaviour
{
    public Transform GeneratorMonetek = null;

    public int ileMonetek = 1;

    public float czasPojawianiaSie = 1f;
    public float licznik = 0f;

    // Update is called once per frame
    void Update ()
    {
        licznik += Time.deltaTime;

        if (licznik >= czasPojawianiaSie)
        {
            if (ileMonetek > 0)
            {
                //Tutaj losujemy pozycje
                transform.position = new Vector3(-1, 1 ,-7);
                //Tutaj generujemy monetki
                Instantiate(GeneratorMonetek);
                --ileMonetek;
            }
            licznik = 0f;
        }
		
	}
}
