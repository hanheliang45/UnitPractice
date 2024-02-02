using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnSpeed;
    [SerializeField] Transform enemy;
    [SerializeField] float EnemyY;
    int enemySpawned;
    float stopWatch = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stopWatch>=spawnSpeed) 
        {
            Transform newEnemy = Instantiate(enemy, this.transform);
            //newEnemy.transform.position = this.transform.position;
            newEnemy.transform.position = new Vector3(this.transform.position.x, EnemyY, this.transform.position.z);
            stopWatch = 0;
            enemySpawned++;
        }
        
        stopWatch += Time.deltaTime;
    }
}
