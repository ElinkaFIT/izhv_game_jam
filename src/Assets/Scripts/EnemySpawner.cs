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
    public GameObject[] enemyObjects;
    private bool[] floorHasEnemy = Enumerable.Repeat<bool>(false, numOfFloors).ToArray();
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //float distToPlayer = Vector2.Distance(transform.position, player.position);
        //bool chasingAllowed = (distToPlayer < agroRange && player.position.y < transform.position.y + 2 && player.position.y > transform.position.y - 1);
        for (int i = 0; i < numOfFloors; i++)
        {
            float distToPlayer = Vector2.Distance(floorSpawnPoints[i].position, player.position);
            if (distToPlayer < agroRange && !floorHasEnemy[i])
            {
                Instantiate(enemyObjects[0], floorSpawnPoints[i].position, transform.rotation);
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
