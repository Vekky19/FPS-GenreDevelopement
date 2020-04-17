using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;

    public Transform[] spawnPoints;

    public float spawnTime = 180f;
    float timer;

    void Update()
    {
        timer++;
        if (timer > spawnTime)
        {
            timer = 0;
            Instantiate(zombiePrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, this.transform.rotation);
        }
    }
}
