using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject Fish;

    public bool stopSpawning1 = false;
    public bool stopSpawning2 = false;
    public float spawnTime;
    public float spawnDelay;

    public List<GameObject> fishes = new List<GameObject>();

    public int fishCounter1;
    public int fishCounter2;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnFish1", spawnTime, spawnDelay);
        InvokeRepeating("SpawnFish2", spawnTime, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        if(stopSpawning1 == true && fishCounter1 < 10)
        {   
            InvokeRepeating("SpawnFish1", 1, 2);
            Debug.Log("çalýþtý");
            stopSpawning1 = false;
        }

        if (stopSpawning2 == true && fishCounter2 < 10)
        {
            InvokeRepeating("SpawnFish2", 1, 2);
            Debug.Log("çalýþtý2");
            stopSpawning2 = false;
        }
    }

    public void SpawnFish1()
    {
        Vector3 position = new Vector3(Random.Range(-0.5F, 0.5F), 1, Random.Range(-0.5F, 0.5F));  //Random spawn area
        if (Fish != null)
        {
            Instantiate(Fish, position, Quaternion.identity);
        }
        fishCounter1++;

        if (fishCounter1 > 10)
        {
            CancelInvoke("SpawnFish1");
            stopSpawning1 = true;
        }
    }

    public void SpawnFish2()
    {
        Vector3 position = new Vector3(Random.Range(20F, 22F), 1, Random.Range(5F, 7F));  //Random spawn area
        if (Fish != null)
        {
            Instantiate(Fish, position, Quaternion.identity);
        }
        fishCounter2++;
        if (fishCounter2 > 10)
        {
            CancelInvoke("SpawnFish2");
            stopSpawning2 = true;
        }
    }
}
