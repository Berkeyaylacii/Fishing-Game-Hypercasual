using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner2 : MonoBehaviour
{
    public GameObject boat;

    public GameObject Fish3;
    public GameObject Fish4;

    public bool stopSpawning3 = false;
    public bool stopSpawning4 = false;

    public float spawnTime;
    public float spawnDelay;

    public int fishCounter3;
    public int fishCounter4;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnFish3", spawnTime, spawnDelay);
        InvokeRepeating("SpawnFish4", spawnTime, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {   

        if (stopSpawning3 == true && fishCounter3 < 10)  //Fish should spawn if boat is away from the fish stack.
        {
            InvokeRepeating("SpawnFish3", 1, 3);
            Debug.Log("çalýþtý3");
            stopSpawning3 = false;
        }

        if (stopSpawning4 == true && fishCounter4 < 10)
        {
            InvokeRepeating("SpawnFish4", 1, 3);
            Debug.Log("çalýþtý4");
            stopSpawning4 = false;
        }
    }

    public void SpawnFish3()
    {
        Vector3 position = new Vector3(Random.Range(13F, 13.5F), 1, Random.Range(53F, 53.5F));  //Random spawn area
        if (Fish3 != null)
        {
            Instantiate(Fish3, position, Quaternion.identity);
        }
        fishCounter3++;

        if (fishCounter3 > 10)
        {
            CancelInvoke("SpawnFish3");
            stopSpawning3 = true;
        }
    }

    public void SpawnFish4()
    {
        Vector3 position = new Vector3(Random.Range(-14F, -14.5F), 1, Random.Range(52F, 52.5F));  //Random spawn area
        if (Fish4 != null)
        {
            Instantiate(Fish4, position, Quaternion.identity);
        }
        fishCounter4++;

        if (fishCounter4 > 10)
        {
            CancelInvoke("SpawnFish4");
            stopSpawning4 = true;
        }
    }
}
