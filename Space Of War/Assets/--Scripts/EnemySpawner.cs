using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Enemy prefab
    public GameObject Enemy;

    // spawn rate

    float maxSpawnRateInSeconds = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnEnemy", maxSpawnRateInSeconds);

        // increse spawn rate every 30 seconds
        InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /* Function to spawn enemy
     * This function will create  an enemy prefab
     * positioned on the top edge of  the screen,
     * and randomly between the left and right edge og the screen
    */
    void SpawnEnemy()
    {
        // bottom left point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        // top right point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        // instantiate an enemy
        GameObject anEnmy = (GameObject)Instantiate(Enemy);
        anEnmy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        // schedule enemy spawn
        ScheduleEnemySpawn();
    }

    void ScheduleEnemySpawn()
    {
        float spawnTime;

        if (maxSpawnRateInSeconds > 1f)
        {
            // pick a random number between 1 and maxSpawnRateInSeconds
            spawnTime = Random.Range(1f, maxSpawnRateInSeconds);
        }
        else
            spawnTime = 1f;

        Invoke("SpawnEnemy", spawnTime);
    }

    // Function to increase dificulty of the level
    void IncreaseSpawnRate()
    {
        if(maxSpawnRateInSeconds > 1f)
        {
            maxSpawnRateInSeconds--;
        }
        if(maxSpawnRateInSeconds == 1f)
        {
            CancelInvoke("IncreaseSpawnRate");
        }
    }
}
