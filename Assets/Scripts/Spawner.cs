using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject[] hazards;

    private float timeBetweenSpawns;
    public float startTimeBetweenSpawns;

    public float minTimeBetweenSpawns;
    public float decrease;


    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            updateSpawner();
        }
    }

    private void updateSpawner()
    {
        if (timeBetweenSpawns <= 0)
        {
            //spawn hazaed
            Transform randomSpawnPoint = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];

            GameObject randomHazard = hazards[UnityEngine.Random.Range(0, hazards.Length)];

            Instantiate(randomHazard, randomSpawnPoint.position, Quaternion.identity);

            DecreaseTimeBetweenSpawns();
            timeBetweenSpawns = startTimeBetweenSpawns;
        }
        else
        {
            timeBetweenSpawns -= Time.deltaTime;
        }
    }

    private void DecreaseTimeBetweenSpawns()
    {
        if(startTimeBetweenSpawns > minTimeBetweenSpawns)
        {
            startTimeBetweenSpawns -= decrease;
        }
    }
}
