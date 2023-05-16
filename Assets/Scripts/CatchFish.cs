using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Search;

public class CatchFish : MonoBehaviour
{
    public FishSpawner FishSpawner;

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
            if (distance < 3f && catchedFishCount < float.Parse(boatCapacityText.text.ToString()) )  //Check if fish is close and enough boat capacity
            {
                line.enabled = true;
                closest = fish;

                line.positionCount = 2;
                line.SetPosition(0, gameObject.transform.position);
                line.SetPosition(1, closest.transform.position);

                float distancee = Vector3.Distance(closest.transform.position, bringPosition.position);
                float catchStrength = Time.deltaTime * strength;
                closest.transform.position = Vector3.Lerp(closest.transform.position, bringPosition.position, catchStrength);

                if(distance < 1f)
                {
                    //float skor = float.Parse(score_txt.text);
                    //skor = skor + 1;
                    // score_txt.text = skor.ToString();
                    
                    catchedFishCount += 1;
                    catchedFishText.text = catchedFishCount.ToString();

                    line.enabled = false;

                    if(closest.name == "Fish1(Clone)")
                    {
                        FishSpawner.fishCounter1 -= 1; //decrease spawnedFish1 count to spawn fish again.
                        catchedFish1Count += 1;
                    }
                    if (closest.name == "Fish2(Clone)")
                    {
                        FishSpawner.fishCounter2 -= 1;  //decrease spawnedFish2 count to spawn fish again.
                        catchedFish2Count += 1; 
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
        totalMoney += catchedFish1Count*1 + catchedFish2Count * 2;

        totalMoneyText.text = totalMoney.ToString();
    }

    public void resetCatchedFishCount()
    {
        catchedFishCount = 0;
        catchedFish1Count = 0;
        catchedFish2Count = 0;
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
