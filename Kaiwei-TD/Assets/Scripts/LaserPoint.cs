using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPoint : MonoBehaviour
{
    [SerializeField] Aiming aiming;
    [SerializeField] int laserDamage;
    [SerializeField] float damageSpeed;
    float stopWatch;
    void Start()
    {
             
    }

   
    void Update()
    {
        Transform targetEnemy = aiming.GetEnemy();
        if (targetEnemy == null) 
        {
            return;
        }
        if (stopWatch > damageSpeed) 
        {
            this.Hit(targetEnemy);
            stopWatch = 0;
        }
            stopWatch += Time.deltaTime;
    }

    public void Hit(Transform targetEnemy) 
    {
        Debug.Log("zZzZzZzZz");
        targetEnemy.parent.GetComponent<Enemy>().TakeDamage(laserDamage);
    }
}
