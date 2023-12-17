using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{ 
    [SerializeField] Transform copy;
    [SerializeField] float spawnSpeed;
    [SerializeField] int offset;
    float stopWatch = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stopWatch > spawnSpeed) {
            Transform newPipeSet= Instantiate(copy, this.transform);
            newPipeSet.position += new Vector3(0, Random.Range( -offset, offset),0);
            stopWatch = 0;
        }
        stopWatch += Time.deltaTime;


    }
}
