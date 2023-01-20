using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetSpawner : MonoBehaviour
{
    public FishSpawner fishSpawner;

    GameObject[] fishes;
    GameObject closest;

    private LineRenderer line;
    public Transform bringPosition;
    public GameObject fish;
    bool pulling;

    // Start is called before the first frame update
    void Start()
    {
        line = gameObject.GetComponent < LineRenderer>();
        pulling = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (pulling)
        {
            line.positionCount = 2;
            line.SetPosition(0, gameObject.transform.position);
            line.SetPosition(1, fish.transform.position);

            float distance = Vector3.Distance(fish.transform.position, bringPosition.position);
            fish.transform.position = Vector3.Lerp(fish.transform.position, bringPosition.position, Time.deltaTime * 5);
            if (distance < 0.20f)
            {
                
            }
        }*/
        /*if (Input.GetButtonDown("Fire1"))
        {
            BringFish();
        }*/

        Detect();
    }
    

    void BringFish()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(camRay, out hit, 1000))
        {
            if (hit.collider.tag == "pullable")
            {
                fish = hit.collider.gameObject;
                pulling = true;
            }
        }
    }

    public void Detect()
    {
        fishes = GameObject.FindGameObjectsWithTag("Fish");
        Vector3 position = transform.position;
        foreach (GameObject fish in fishes)
        {
            Vector3 diff = fish.transform.position - position;
            float distance = diff.magnitude;
            Debug.Log("Distance is:" + distance);
            if (distance < 10f)
            {
                closest = fish;

                line.positionCount = 2;
                line.SetPosition(0, gameObject.transform.position);
                line.SetPosition(1, closest.transform.position);

                float distancee = Vector3.Distance(closest.transform.position, bringPosition.position);
                closest.transform.position = Vector3.Lerp(closest.transform.position, bringPosition.position, Time.deltaTime * 5);
            }

        }

        //Debug.Log("Close one is:" + closest);


    }

}
