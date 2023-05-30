using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Search;

public class CatchFish : MonoBehaviour
{
    public FishSpawner FishSpawner;
    public FishSpawner2 FishSpawner2;
    public FishSpawner3 FishSpawner3;

    public GateController GateController;

    GameObject[] fishes;
    GameObject[] cashes;
    GameObject closest;

    public LineRenderer line;
    public Transform bringPosition;
    public GameObject fish;
    public GameObject cash;

    TextMeshProUGUI score_txt;
    public TextMeshPro catchedFishText;
    public TextMeshPro boatCapacityText;
    public TextMeshProUGUI totalMoneyText;

    public Transform spawnPoint;
    public Transform cashUI;

    private Camera mainCamera;

    float elapsedTime;
    float desiredDuration = 150f;

    public float strength = 10f;
    public float totalMoney;

    public float boatCapacity;
    public float catchedFishCount = 0;
    public float catchedFish1Count = 0;
    public float catchedFish2Count =0 ;
    public float catchedFish3Count = 0;
    public float catchedFish4Count = 0;
    public float catchedFish5Count = 0;
    public float catchedFish6Count = 0;

    public bool isCatching = false;
    public bool moveCash = false;
    // Start is called before the first frame update
    void Start()
    {       
        mainCamera = Camera.main;

        line.enabled = false;
        score_txt = GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshProUGUI>();
      
    }

    // Update is called once per frame
    void Update()
    {
        DetectandCatch();

        if (GateController.gate1isOpen == true)
        {
            FishSpawner2 = GameObject.FindGameObjectWithTag("FishSpawner").GetComponent<FishSpawner2>();
        }
        if(GateController.gate2isOpen == true)
        {
            FishSpawner3 = GameObject.FindGameObjectWithTag("FishSpawner").GetComponent<FishSpawner3>();
        }
        /*if(moveCash == true)
        {
            MoveCashObject();
        }*/
    }
    
    void MoveCashObject()
    {
        Vector3 targetPos = GetCashUIIconPosition(cash.transform.position);

        cashes = GameObject.FindGameObjectsWithTag("Cash");

        foreach (GameObject cash in cashes)
        {
            cash.transform.position = Vector3.MoveTowards(cash.transform.position, targetPos, Time.deltaTime);

            if (Vector3.Distance(cash.transform.position, targetPos) < 2f)
            {
                //GameObject.Destroy(cash);
            }
        }
    }
    public void DetectandCatch()         //Catch the fish by moving it to the boat position with line renderer
    {        
        fishes = GameObject.FindGameObjectsWithTag("Fish");
        Vector3 position = transform.position;  
        foreach (GameObject fish in fishes)
        {
            Vector3 diff = fish.transform.position - position;
            float distance = diff.magnitude;
            //boatCapacity = float.Parse(boatCapacityText.text.ToString());
            if (distance < 3f && catchedFishCount < float.Parse(boatCapacityText.text.ToString()))  //Check if fish is close and enough boat capacity
            {
                line.enabled = true;  
                closest = fish;

                line.positionCount = 2;
                line.SetPosition(0, bringPosition.transform.position);
                line.SetPosition(1, closest.transform.position);

                float distancee = Vector3.Distance(closest.transform.position, bringPosition.position);  //burasýýý
                float catchStrength = Time.deltaTime * strength;
                closest.transform.position = Vector3.Lerp(closest.transform.position, bringPosition.position, catchStrength);   //burasýýýý

                if(distance < 1f)
                {
                    //float skor = float.Parse(score_txt.text);
                    //skor = skor + 1;
                    // score_txt.text = skor.ToString();
                    
                    catchedFishCount += 1;
                    catchedFishText.text = catchedFishCount.ToString();

                    line.enabled = false;

                    if(closest.name == "LiveSharkSucker(Clone)")
                    {
                        FishSpawner.fishCounter1 -= 1; //decrease spawnedFish1 count to spawn fish again.
                        catchedFish1Count += 1;
                    }
                    if (closest.name == "Catfish(Clone)")
                    {
                        FishSpawner.fishCounter2 -= 1;  //decrease spawnedFish2 count to spawn fish again.
                        catchedFish2Count += 1; 
                    }
                    if (closest.name == "Dolphinfish(Clone)")
                    {
                        FishSpawner2.fishCounter3 -= 1;  //decrease spawnedFish2 count to spawn fish again.
                        catchedFish3Count += 1;
                    }
                    if (closest.name == "LargeToothFlounders(Clone)")
                    {
                        FishSpawner2.fishCounter4 -= 1;  //decrease spawnedFish2 count to spawn fish again.
                        catchedFish4Count += 1;
                    }
                    if (closest.name == "BluefinTuna(Clone)")
                    {
                        FishSpawner3.fishCounter5 -= 1;  //decrease spawnedFish2 count to spawn fish again.
                        catchedFish5Count += 1;
                    }
                    if (closest.name == "SawShark(Clone)")
                    {
                        FishSpawner3.fishCounter6 -= 1;  //decrease spawnedFish2 count to spawn fish again.
                        catchedFish6Count += 1;
                    }

                    Object.Destroy(closest);

                    //Generate cash and move to the icon position
                    //Instantiate(cash, position, Quaternion.identity);
                    //moveCash = true;
                }
            }
        }
    }

    public void IncreaseScore()
    {
        totalMoneyText.text = (float.Parse(totalMoneyText.text) + catchedFish1Count*1 + catchedFish2Count* 2 + catchedFish3Count* 3 + catchedFish4Count* 4).ToString();
    }

    public void resetCatchedFishCount()
    {
        catchedFishCount = 0;
        catchedFish1Count = 0;
        catchedFish2Count = 0;
        catchedFish3Count = 0;
        catchedFish4Count = 0;
        catchedFishText.text = catchedFishCount.ToString();
    }

    public Vector3 GetCashUIIconPosition(Vector3 target)
    {
        Vector3 uiPos = cashUI.position;
        uiPos.z = (target - mainCamera.transform.position).z ;

        Vector3 result = mainCamera.ScreenToWorldPoint(uiPos);

        return result;
    }

}
