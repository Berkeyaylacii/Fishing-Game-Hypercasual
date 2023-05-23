using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner3 : MonoBehaviour
{
    public GameObject boat;

    public GameObject Fish5;
    public GameObject Fish6;

    public bool stopSpawning5 = false;
    public bool stopSpawning6 = false;

    public float spawnTime;
    public float spawnDelay;

    public int fishCounter5;
    public int fishCounter6;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnFish3", spawnTime, spawnDelay);
        InvokeRepeating("SpawnFish4", spawnTime, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {

        if (stopSpawning5 == true && fishCounter5 < 10)  //Fish should spawn if boat is away from the fish stack.
        {
            InvokeRepeating("SpawnFish5", 1, 3);
            Debug.Log("çalýþtý3");
            stopSpawning5 = false;
        }

        if (stopSpawning6 == true && fishCounter6 < 10)
        {
            InvokeRepeating("SpawnFish6", 1, 3);
            Debug.Log("çalýþtý4");
            stopSpawning6 = false;
        }
    }

    public void SpawnFish5()
    {
        Vector3 position = new Vector3(Random.Range(-27F, -27.5F), 1, Random.Range(-20F, -20.5F));  //Random spawn area
        if (Fish5 != null)
        {
            Instantiate(Fish5, position, Quaternion.identity);
        }
        fishCounter5++;

        if (fishCounter5 > 10)
        {
            CancelInvoke("SpawnFish3");
            stopSpawning5 = true;
        }
    }

    public void SpawnFish6()
    {
        Vector3 position = new Vector3(Random.Range(-42F, -42.5F), 1, Random.Range(-31F, -31.5F));  //Random spawn area
        if (Fish6 != null)
        {
            Instantiate(Fish6, position, Quaternion.identity);
        }
        fishCounter6++;

        if (fishCounter6 > 10)
        {
            CancelInvoke("SpawnFish4");
            stopSpawning6 = true;
        }
    }
}
