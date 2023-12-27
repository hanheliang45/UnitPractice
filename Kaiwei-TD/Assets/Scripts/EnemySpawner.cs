using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    float stopWatch = 0;
    [SerializeField] Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stopWatch>=0.5) 
        {
            Instantiate(enemy,this.transform);
            stopWatch = 0;
        }
        stopWatch += Time.deltaTime;
    }
}
