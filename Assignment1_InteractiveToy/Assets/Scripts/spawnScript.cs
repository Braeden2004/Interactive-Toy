using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnScript : MonoBehaviour
{
    //Initiate enemyobject
    public GameObject enemy;

    void Start()
    {
        //Call the spawn enemy function every 2 seconds
        InvokeRepeating("SpawnEnemy", 1, 1);
    }

    void SpawnEnemy()
    {
        Vector2 spawnPos = new Vector2(0, 20);
        Instantiate(enemy, spawnPos, Quaternion.identity);
    }
}
