using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetSpawner : MonoBehaviour
{
    public GameObject Net;

    public float distance = 1f;

    public float Timer = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
       /*if (Input.GetButton("C"))
        {
           StartCoroutine(waiter());
        }*/
 
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0f)
        {
            if (Input.GetKey(KeyCode.C))
            {
                SpawnNet();
            }
            Timer = 0.05f;
        }
    }

    void SpawnNet()
    {   
        Instantiate(Net, transform.position - transform.forward * distance, transform.rotation);
    }

    /*
    IEnumerator waiter()
    {
            yield return null;
            yield return new WaitForSeconds(1);
            Instantiate(Net, transform.position - transform.forward * distance, transform.rotation);
    }*/
}
