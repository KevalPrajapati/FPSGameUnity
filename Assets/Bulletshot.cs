using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletshot : MonoBehaviour
{
    protected bool letPlay = true;


    // Start is called before the first frame update
    void Start()
    { 
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            letPlay = !letPlay;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (!gameObject.GetComponent<ParticleSystem>().isPlaying)
            {
                gameObject.GetComponent<ParticleSystem>().Play();
            }
        }
        else
        {
            if (gameObject.GetComponent<ParticleSystem>().isPlaying)
            {
                gameObject.GetComponent<ParticleSystem>().Stop();
            }
        }


    }
}
