﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMotor : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private Vector3 velocity = Vector3.zero;
    private Rigidbody rb;
    private Vector3 rotation = Vector3.zero;
    private Vector3 cameraRotation = Vector3.zero;
    private float cameraRotationX = 0f;
    [SerializeField]
    private float cameraRotationLimit = 85f;
    private float currentCameraRotationX = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    public void Move (Vector3 _velocity)
	{
		velocity = _velocity;
	}
    // Gets a rotational vector
    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    //Gets a rotational vector for the camera

    public void RotateCamera(float _cameraRotationX)
    {
        cameraRotationX = _cameraRotationX;
    }

    // Run every physics iteration
    void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    //Perform movement based on velocity variable
    void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }

       // if (thrusterForce != Vector3.zero)
        //{
           // rb.AddForce(thrusterForce * Time.fixedDeltaTime, ForceMode.Acceleration);
        //}

    }
    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if (cam != null)
        {
            // Set our rotation and clamp it
                currentCameraRotationX -= cameraRotationX;
                currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

            //Apply our rotation to the transform of our camera
            cam.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
