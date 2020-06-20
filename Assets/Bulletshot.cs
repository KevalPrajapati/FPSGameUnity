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
        if (Input.GetKeyDown(KeyCode.E))
        {
            letPlay = !letPlay;
        }

        if (letPlay)
        {
            if (!gameObject.particleSystem.isPlaying)
            {
                gameObject.particleSystem.Play();
            }
        }
        else
        {
            if (gameObject.particleSystem.isPlaying)
            {
                gameObject.particleSystem.Stop();
            }
        }


    }
}
