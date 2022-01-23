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

	//coins
	public GameObject coinObject;

    // Start is called before the first frame update
    void Start()
    {
		// coin spawner
		float length;
		float step;
		int random;
		Vector3 position;
		for (int i = 0; i < numOfFloors; i++)
        {
            length = (numOfFloors - i) * 10;
			step = (0 - (length/2)) + 2;
			while (step < (length/2 - 2))
			{
				int[] array = new int[]{0, 1, 0, 2, 0, 0};
				random = Random.Range(0, 6);
				int choice = array[random];

				 switch(choice)
            	{
               	 	case 1:
						position = new Vector3(step, floorSpawnPoints[i].position.y + 0.0f, 0);
						Instantiate(coinObject, position, transform.rotation);
						break;
                	case 2:
						position = new Vector3(step,floorSpawnPoints[i].position.y + 3.0f, 0);
						Instantiate(coinObject, position, transform.rotation);
						break;
					default: break;
            	}
				step+=4;
			}			
		} 

    }

    // Update is called once per frame
    void Update()
    {
        int enemyID = 0;
        for (int i = 1; i < numOfFloors; i++)
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
    }

}
