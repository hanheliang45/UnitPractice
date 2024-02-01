using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPoint : MonoBehaviour
{
    [SerializeField] Aiming aiming;
    [SerializeField] int laserDamage;
    [SerializeField] float damageSpeed;
    [SerializeField] float SlowDownEnemy;
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
        Enemy e = targetEnemy.parent.GetComponent<Enemy>();
        e.TakeDamage(laserDamage);
        e.Slow(SlowDownEnemy/100f);
    }
}
