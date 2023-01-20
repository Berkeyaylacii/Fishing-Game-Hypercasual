using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CatchFish : MonoBehaviour
{   

    TextMeshProUGUI score_txt;

    GameObject[] fishes;
    GameObject closest;

    private LineRenderer line;
    public Transform bringPosition;
    public GameObject fish;

    public GameObject cash;
    public GameObject cashUI;

    GameObject cube;

    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        line = gameObject.GetComponent < LineRenderer>();
        mainCamera = Camera.main;

        cashUI = GameObject.FindGameObjectWithTag("CashUI");

        line.enabled = false;
        score_txt = GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        DetectandCatch();

    }
    
    public void DetectandCatch()
    {   
        
        fishes = GameObject.FindGameObjectsWithTag("Fish");
        Vector3 position = transform.position;
        foreach (GameObject fish in fishes)
        {
            Vector3 diff = fish.transform.position - position;
            float distance = diff.magnitude;
            if (distance < 10f)
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

                    /*Vector3 targetPos = GetIconPosition(cash.transform.position);
                    cash.transform.position = Vector3.Lerp(cash.transform.position, targetPos, Time.deltaTime * 5f);*/
                }

            }

        }


    }

    public Vector3 GetIconPosition(Vector3 target)
    {
        Vector3 uiPos = cashUI.transform.position;
        uiPos.z = (target - mainCamera.transform.position).z ;

        Vector3 result = mainCamera.ScreenToWorldPoint(uiPos);

        return result;
    }

}
