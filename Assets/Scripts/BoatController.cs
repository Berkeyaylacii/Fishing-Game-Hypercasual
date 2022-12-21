using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    /*[SerializeField] private float _xLimit;

    [SerializeField] private float _zLimit;


    public float speed = .1f;
    public float rotateSpeed = .01f;*/
    // Start is called before the first frame update
    public float turnSpeed = 1000f;
    public float acceleratespeed = 1000f;

    private Rigidbody rbody;

    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /*  float newX;
          float newZ;

          float xDirection = Input.GetAxis("Horizontal");
          float zDirection = Input.GetAxis("Vertical");

          newX = transform.position.x + xDirection * speed ;
          newX = Mathf.Clamp(newX, -_xLimit, _xLimit);

          newZ = transform.position.z + zDirection * speed ;
          newZ = Mathf.Clamp(newZ, -_zLimit, _zLimit);


          transform.position = new Vector3(newX, transform.position.y, newZ);
          transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * rotateSpeed);*/

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        rbody.AddTorque(0f, h * turnSpeed * Time.deltaTime, 0f);
        rbody.AddForce(transform.forward * v * acceleratespeed * Time.deltaTime);
    }


}
