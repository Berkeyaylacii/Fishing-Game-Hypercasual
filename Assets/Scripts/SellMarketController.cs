using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SellMarketController : MonoBehaviour
{
    public CatchFish CatchFish;
    public CollectCashAnimation CollectCashAnimation;

    public GameObject sellMarket;
    public GameObject boat;

    public TextMeshPro boatCapacity;

    public bool isSellMarketOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(boat.transform.position, sellMarket.transform.position);

        if (distance > 3f)
        {
            isSellMarketOpen = false;        
        }

        if (distance < 3f && isSellMarketOpen == false && CatchFish.catchedFishCount > 0) //Increase the score
        {
            isSellMarketOpen = true;

            Debug.Log("All Fish Sold.");

            CatchFish.IncreaseScore();  
            CatchFish.resetCatchedFishCount();
        }
    }

    void IncreaseBoatCapacity()
    {

    }
}
