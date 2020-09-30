using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSpawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject goal;
    public static bool goalTouched = false;

    int randomSpawnPoint;
    int lastSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    void Update()
    {
        if (goalTouched)
        {
            Spawn();
            goalTouched = false;
        }
            
    }

    public void Spawn()
    {
        do
        {
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            if (randomSpawnPoint == 4 && lastSpawnPoint == 0)           // Forces redo generation if the spawn is impossible to achieve
                randomSpawnPoint = lastSpawnPoint;
        } while (randomSpawnPoint == lastSpawnPoint);                   // Redo generation if at same location

        
       
        Instantiate(goal, spawnPoints[randomSpawnPoint].position, Quaternion.identity);
        lastSpawnPoint = randomSpawnPoint;
    }
}
