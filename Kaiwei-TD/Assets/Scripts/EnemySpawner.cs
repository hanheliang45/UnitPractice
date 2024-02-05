using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemySpawner : MonoBehaviour
{
    public event EventHandler<int> OnNewWave;
    [SerializeField] float spawnSpeed;
    [SerializeField] Transform enemy;
    [SerializeField] float EnemyY;
    [SerializeField] int enemysPerWave;
    [SerializeField] float timeBetweenWaves;
    int waveNumber = 1;
    int enemySpawned;
    float timeBetweenWavesTimer;
    float stopWatch = 0;
    bool canSpawn = true;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemySpawned == enemysPerWave) 
        {
            canSpawn = false;  
        }
        if (!canSpawn) 
        {
            timeBetweenWavesTimer += Time.deltaTime;
        }
        if (timeBetweenWavesTimer >= timeBetweenWaves) 
        {
            canSpawn = true;
            enemySpawned = 0;
            timeBetweenWavesTimer = 0;
            waveNumber++;
            Debug.Log(waveNumber);
            OnNewWave?.Invoke(this,waveNumber);
            enemysPerWave *= 2;
        }
        stopWatch += Time.deltaTime;
        if (stopWatch >= spawnSpeed)
        {
            if (!canSpawn) 
            {
                return;
            }
            Transform newEnemy = Instantiate(enemy, this.transform);
            //newEnemy.transform.position = this.transform.position;
            newEnemy.transform.position = new Vector3(this.transform.position.x, EnemyY, this.transform.position.z);
            stopWatch = 0;
            enemySpawned++;
        }
    }
    
}
