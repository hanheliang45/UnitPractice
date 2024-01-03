using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFirePoint : MonoBehaviour
{


    float stopWatch = 0;
    [SerializeField] Gun gun;
    [SerializeField] Transform copy;
    [SerializeField] float fireSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform enemy = gun.GetEnemy();
        if (enemy == null) 
        {
            return;
        }
        if (stopWatch >= fireSpeed) 
        {
            Debug.Log("Pew! Pew!! Pew!!!");
            Instantiate(copy,transform);
            stopWatch = 0;
        }
        stopWatch += Time.deltaTime;

    }
}
