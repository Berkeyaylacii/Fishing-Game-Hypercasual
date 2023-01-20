using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public GameObject fish;

    GameObject[] fishes;
    GameObject closest;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Detect();
    }

    public void Detect()
    {
        fishes = GameObject.FindGameObjectsWithTag("Fish");
        Vector3 position = transform.position;
        foreach(GameObject fish in fishes)
        {
            Vector3 diff = fish.transform.position - position;
            float distance = diff.magnitude;
            Debug.Log("Distance is:"+distance);
            if(distance < 10f)
            {
                closest = fish;
            }
            
        }

        Debug.Log("Close one is:" + closest);

        
    }
}
