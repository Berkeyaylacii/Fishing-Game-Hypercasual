using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoatController : MonoBehaviour
{
    public float turnSpeed = 1000f;
    public float acceleratespeed = 1000f;

    private Rigidbody rbody;

    [SerializeField] private float fuel = 100f;
    [SerializeField] private Slider fuelSlider;
    [SerializeField] private float fuelBurnRate = 20f;

    private float currentFuel;
    private bool isMoving = false;

    void Start()
    {
        rbody = GetComponent<Rigidbody>();

        currentFuel = fuel;
    }

    // Update is called once per frame
    void Update()
    {
        moveBoat();

        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0f || Mathf.Abs(Input.GetAxis("Vertical")) > 0f)
        {
            consumeFuel();
        } 
        
    }

    void consumeFuel()
    {
        currentFuel -= fuelBurnRate * Time.deltaTime;
    }

    void moveBoat()
    {   
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        rbody.AddTorque(0f, h * turnSpeed * Time.deltaTime, 0f);
        rbody.AddForce(transform.forward * v * acceleratespeed * Time.deltaTime);
   
        fuelSlider.value = currentFuel / fuel;
        isMoving = true;
    }

}
