using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyMarketPanelManager : MonoBehaviour
{
    BuyMarketController BuyMarketController;

    public GameObject boat;

    public GameObject buyPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openBuyPanel()
    {
        boat.GetComponent<BoatMovementTouch>().enabled = false;
        buyPanel.SetActive(true);
    }

    public void closeBuyPanel()
    {
        boat.GetComponent<BoatMovementTouch>().enabled = true;
        buyPanel.SetActive(false);
    }
}
