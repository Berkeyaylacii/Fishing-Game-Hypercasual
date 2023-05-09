using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelMarketController : MonoBehaviour
{
    public GameObject fuelMarket;

    public GameObject boat;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(boat.transform.position, fuelMarket.transform.position);

        if (distance < 3f)
        {
            Debug.Log("Fuel market");
        }
    }
}
