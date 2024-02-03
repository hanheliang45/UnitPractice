using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPoint : MonoBehaviour
{
    private LineRenderer laser;
    [SerializeField] Aiming aiming;
    [SerializeField] int laserDamage;
    [SerializeField] float damageSpeed;
    [SerializeField] float SlowDownEnemy;
    [SerializeField] float slowDuration;
    float stopWatch;
    void Start()
    {
        laser = GetComponent<LineRenderer>();         
        laser.enabled = false;
    }

   
    void Update()
    {
        Transform targetEnemy = aiming.GetEnemy();
        if (targetEnemy == null) 
        {
            laser.enabled = false;
            return;
        }
        if (stopWatch > damageSpeed) 
        {
            this.Hit(targetEnemy);
            stopWatch = 0;
        }
            stopWatch += Time.deltaTime;
            ShowLaser(targetEnemy);
    }

    void ShowLaser(Transform targetEnemy) 
    {
        laser.SetPosition(0,this.transform.position);
        laser.SetPosition(1, targetEnemy.position);
        laser.enabled = true;
    }

    public void Hit(Transform targetEnemy) 
    {
        //Debug.Log("zZzZzZzZz");
        Enemy e = targetEnemy.parent.GetComponent<Enemy>();
        e.TakeDamage(laserDamage);
        e.Slow(SlowDownEnemy/100f, slowDuration);
    }
}
