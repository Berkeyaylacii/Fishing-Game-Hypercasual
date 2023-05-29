using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GateController : MonoBehaviour
{   
    public GameObject FishSpawner;

    public GameObject gate1;
    public GameObject gate1Text;
    public GameObject gate2;
    public GameObject gate2Text;
    public GameObject gate3;
    public GameObject gate3Text;
    public GameObject gate4;
    public GameObject gate4Text;
    public GameObject gate5;
    public GameObject gate5Text;

    public TextMeshPro boatCapacity;

    public GameObject boat;
    public bool gate1isOpen = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   
        //GATES OPENS
        if(float.Parse(boatCapacity.text.ToString()) >= 8 )
        {
            gate1.SetActive(false);
            FishSpawner.GetComponent<FishSpawner2>().enabled = true;
            gate1isOpen = true;
        }

        /////// GATE WARNING TEXTS
        if (gate1 != null)
        {   
            float distance1 = Vector3.Distance(boat.transform.position, gate1.transform.position);
            if(distance1 <= 2f)
            {
                gate1Text.SetActive(true);
            }
            else
            {
                gate1Text.SetActive(false);
            }           
        }

        if (gate2 != null)
        {
            float distance2 = Vector3.Distance(boat.transform.position, gate2.transform.position);
            if (distance2 <= 2f)
            {
                gate2Text.SetActive(true);
            }
            else
            {
                gate2Text.SetActive(false);
            }
        }

        if (gate3 != null)
        {
            float distance3 = Vector3.Distance(boat.transform.position, gate3.transform.position);
            if (distance3 <= 2f)
            {
                gate3Text.SetActive(true);
            }
            else
            {
                gate3Text.SetActive(false);
            }
        }

        if (gate4 != null)
        {
            float distance4 = Vector3.Distance(boat.transform.position, gate4.transform.position);
            if (distance4 <= 2f)
            {
                gate4Text.SetActive(true);
            }
            else
            {
                gate4Text.SetActive(false);
            }
        }

        if (gate5 != null)
        {
            float distance5 = Vector3.Distance(boat.transform.position, gate5.transform.position);
            if (distance5 <= 2f)
            {
                gate5Text.SetActive(true);
            }
            else
            {
                gate5Text.SetActive(false);
            }
        }

    }

}
