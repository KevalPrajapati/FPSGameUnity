using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletshot : MonoBehaviour
{
    public float moveSpeed;
    private Vector3 input;
    private Rigidbody r;
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButton("Jump`")) {
            input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            r.AddForce(input * Time.deltaTime * moveSpeed/100000);
        }


    }
}
