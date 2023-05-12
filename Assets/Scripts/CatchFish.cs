using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    public TextMeshProUGUI totalMoneyText;

    public Transform spawnPoint;
    public Transform cashUI;

    private Camera mainCamera;

    float elapsedTime;
    float desiredDuration = 150f;

    public float strength;
    public float totalMoney;
    public float catchedFishCount;

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
    public void DetectandCatch()
    {        
        fishes = GameObject.FindGameObjectsWithTag("Fish");
        Vector3 position = transform.position;  //spawn olarak de�i�ti
        foreach (GameObject fish in fishes)
        {
            Vector3 diff = fish.transform.position - position;
            float distance = diff.magnitude;
            if (distance < 3f && catchedFishCount < 5)
            {
                line.enabled = true;
                closest = fish;

                line.positionCount = 2;
                line.SetPosition(0, gameObject.transform.position);
                line.SetPosition(1, closest.transform.position);

                float distancee = Vector3.Distance(closest.transform.position, bringPosition.position);
                strength = Time.deltaTime * 10f;
                closest.transform.position = Vector3.Lerp(closest.transform.position, bringPosition.position, strength);

                if(distance < 1f)
                {
                    //float skor = float.Parse(score_txt.text);
                    //skor = skor + 1;
                    // score_txt.text = skor.ToString();

                    catchedFishCount += 1;
                    catchedFishText.text = catchedFishCount.ToString();

                    line.enabled = false;
                    FishSpawner.fishCounter1 -= 1;
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
        totalMoney += catchedFishCount;

        totalMoneyText.text = totalMoney.ToString();
    }

    public void resetCatchedFishCount()
    {
        catchedFishCount = 0;
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
