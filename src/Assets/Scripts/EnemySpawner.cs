using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float agroRange;
    private static int numOfFloors = 19; // update with floors
    public Transform[] floorSpawnPoints = new Transform[numOfFloors];
    public GameObject[] enemyObjects = new GameObject[5];
    private bool[] floorHasEnemy = Enumerable.Repeat<bool>(false, numOfFloors).ToArray();
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int enemyID = 0;
        for (int i = 0; i < numOfFloors; i++)
        {
            switch (i)
            {
                case <3: enemyID = 0; break;
                case <6: enemyID = 1; break;
                case <9: enemyID = 2; break;
                case <14: enemyID = 3; break;
                case <19: enemyID = 4; break;
            }
            float distToPlayer = Vector2.Distance(floorSpawnPoints[i].position, player.position);
            if (distToPlayer < agroRange && !floorHasEnemy[i])
            {
                Instantiate(enemyObjects[enemyID], floorSpawnPoints[i].position, transform.rotation);
                floorHasEnemy[i] = true;
            }
        }

        /*
            if (Input.GetKeyDown(KeyCode.E)) // todo
        {
            Instantiate(enemyObjects[0], floorSpawnPoints[0].position, transform.rotation);
        }
        */
    }
}
