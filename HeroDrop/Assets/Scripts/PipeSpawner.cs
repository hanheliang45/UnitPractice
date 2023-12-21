using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    float stopWatch = 0;
    [SerializeField] float offSet;
    [SerializeField] float pipeSpawningSpeed;
    [SerializeField] PipeSet copy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Hero.instance.OnKill += Instance_OnKill;
        if (stopWatch >= pipeSpawningSpeed)
        {
            Transform newPipeSet = Instantiate(copy.transform,transform);

            newPipeSet.position += new Vector3(Random.Range(offSet,-offSet), 0,0);
            stopWatch = 0;
        }
        stopWatch += Time.deltaTime;
    }

    private void Instance_OnKill(object sender, System.EventArgs e)
    {
        stopWatch -= Time.deltaTime*2;
    }
}
