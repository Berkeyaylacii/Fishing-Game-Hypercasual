using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuyMarketController : MonoBehaviour
{
    public BuyMarketPanelManager BuyMarketPanelManager;

    public GameObject buyMarket;
    public GameObject boat;

    public TextMeshProUGUI totalMoneyText;
    public TextMeshPro boatCapacityText;
    public TextMeshProUGUI increaseCapPriceText;

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
                BuyMarketPanelManager.openBuyPanel();
                Debug.Log("Buy market");        
            }
        }       
    }

    public void IncreaseBoatCapacity()
    {
        float totalMoney = float.Parse(totalMoneyText.text);
        float boatCap = float.Parse(boatCapacityText.text);
        float increaseBoatCapPrice = float.Parse(increaseCapPriceText.text);

        if(totalMoney >= increaseBoatCapPrice)
        {
            boatCap += 3;
            totalMoney -= increaseBoatCapPrice;

            increaseBoatCapPrice += 10;

            boatCapacityText.text = boatCap.ToString();
            totalMoneyText.text = totalMoney.ToString();
            increaseCapPriceText.text = increaseBoatCapPrice.ToString();       
        }
    }
}
