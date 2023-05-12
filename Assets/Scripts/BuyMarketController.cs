using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyMarketController : MonoBehaviour
{
    public BuyMarketManager BuyMarketManager;

    public GameObject buyMarket;
    public GameObject boat;

    public bool isBuyMarketOpen = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(boat.transform.position, buyMarket.transform.position);

        if(distance > 3f)
        {
            isBuyMarketOpen = false;
            boat.GetComponent<BoatController>().enabled = true;
        }

        if (distance < 3f)
        {   
            if(isBuyMarketOpen == false)
            {
                isBuyMarketOpen = true;
                BuyMarketManager.openBuyPanel();
                Debug.Log("Buy market");        
            }
        }

        
    }
}
