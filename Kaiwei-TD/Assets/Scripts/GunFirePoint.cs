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
        stopWatch += Time.deltaTime;
        Transform enemy = gun.GetEnemy();
        if (enemy == null) 
        {
            return;
        }
        if (stopWatch >= fireSpeed)
        {
            Debug.Log("Pew! Pew!! Pew!!!");
            Transform b = Instantiate(copy, transform.position, Quaternion.identity);
            stopWatch = 0;
            b.GetComponent<Bullet>().SetEnemy(enemy);
        }
    }
}
