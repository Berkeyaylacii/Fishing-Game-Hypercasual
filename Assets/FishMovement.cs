using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;

    Vector3 startPos;
    Vector3 endPos;
    float elapsedTime;
    float desiredDuration = 10f;

    float maxX;
    float maxZ;
    //public float speed;
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        //InvokeRepeating("randNum", 0f, 5f);
        //rb.velocity = RandomVector(0f, 1f);

        startPos = transform.position;

        InvokeRepeating("randNum", 0f, 5f);

        //endPos = new Vector3(maxX, 0, maxZ);
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        float perc = elapsedTime / desiredDuration;

        transform.position = Vector3.Lerp(startPos, endPos, perc);

        
    }

    void randNum()
    {
        float maxX = Random.Range(2f, 5f);
        float maxZ = Random.Range(2f, 5f);

        endPos = new Vector3(maxX, 0, maxZ);
        Debug.Log("X="+ maxX +" Y=" +maxZ);
    }

}
