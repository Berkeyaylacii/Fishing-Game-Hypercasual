using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject Fish;

    public List<GameObject> fishes = new List<GameObject>();

    public int fishCounter;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waiter());
    }

    // Update is called once per frame
    void FixedUpdate()
    {           
            
    }

    IEnumerator waiter()
    {   
        while( fishCounter <= 10)
        {
            yield return null;
            yield return new WaitForSeconds(3);
            Vector3 position = new Vector3(Random.Range(-20.0F, 20.0F), 1, Random.Range(-20.0F, 20.0F));
            
            Instantiate(Fish, position, Quaternion.identity);
            
            
            fishCounter++;            
        }

    }
 
}
