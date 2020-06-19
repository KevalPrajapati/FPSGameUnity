using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float jumph = 3000f;
    // [SerializeField]
    private float lookSensitivity = 20f;

    private Rigidbody rb;

    private PlayerMotor motor;
    // Start is called before the first frame update
    void Start()
    {
        motor = GetComponent<PlayerMotor>();
        rb = GetComponent<Rigidbody>();



    }

    // Update is called once per frame
    void Update()
    {
       float _xMov = Input.GetAxisRaw("Horizontal");
       float _zMov = Input.GetAxisRaw("Vertical");


        Vector3 _movHorizontal = transform.right * _xMov;
		Vector3 _movVertical = transform.forward * _zMov;

		// Final movement vector
		Vector3 _velocity = (_movHorizontal + _movVertical) * speed;
        //apply movement
        motor.Move(_velocity);
        //Calculate rotation as a 3D vector (turning around)
        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;

        //Apply rotation
        motor.Rotate(_rotation);
        //Calculate camera rotation as a 3D vector (turning around)
        float _xRot = Input.GetAxisRaw("Mouse Y");

        float _cameraRotationX = _xRot*lookSensitivity;

        //Apply camera rotation
        motor.RotateCamera(_cameraRotationX);


        //Jump
        if (Input.GetButton("Jump"))
        {
            rb.AddForce(0, jumph * Time.deltaTime, 0 ); 
        }                



    }
}
