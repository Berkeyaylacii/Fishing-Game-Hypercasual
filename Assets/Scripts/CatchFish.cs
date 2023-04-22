using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CatchFish : MonoBehaviour
{   

    TextMeshProUGUI score_txt;

    GameObject[] fishes;
    GameObject[] cashes;
    GameObject closest;

    private LineRenderer line;
    public Transform bringPosition;
    public GameObject fish;

    public GameObject cash;
    public Transform cashUI;

    private Camera mainCamera;

    float elapsedTime;
    float desiredDuration = 150f;

    public bool moveCash = false;
    // Start is called before the first frame update
    void Start()
    {
        line = gameObject.GetComponent < LineRenderer>();
        mainCamera = Camera.main;


        line.enabled = false;
        score_txt = GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        DetectandCatch();
        if(moveCash == true)
        {
            MoveCashObject();
        }
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
        Vector3 position = transform.position;
        foreach (GameObject fish in fishes)
        {
            Vector3 diff = fish.transform.position - position;
            float distance = diff.magnitude;
            if (distance < 3f)
            {
                line.enabled = true;
                closest = fish;

                line.positionCount = 2;
                line.SetPosition(0, gameObject.transform.position);
                line.SetPosition(1, closest.transform.position);

                float distancee = Vector3.Distance(closest.transform.position, bringPosition.position);
                closest.transform.position = Vector3.Lerp(closest.transform.position, bringPosition.position, Time.deltaTime * 5f);

                if(distance < 1f)
                {      
                    float skor = float.Parse(score_txt.text);
                    skor = skor + 1;
                    score_txt.text = skor.ToString();

                    line.enabled = false;
                    Object.Destroy(closest);

                    //Generate cash and move to the icon position
                    Instantiate(cash, position, Quaternion.identity);

                    moveCash = true;
                }
            }
        }
    }


    public Vector3 GetCashUIIconPosition(Vector3 target)
    {
        Vector3 uiPos = cashUI.position;
        uiPos.z = (target - mainCamera.transform.position).z ;

        Vector3 result = mainCamera.ScreenToWorldPoint(uiPos);

        return result;
    }

}
