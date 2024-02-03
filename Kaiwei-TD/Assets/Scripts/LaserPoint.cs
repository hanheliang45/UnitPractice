using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LaserPoint : MonoBehaviour
{
    private LineRenderer laser;
    [SerializeField] Aiming aiming;
    [SerializeField] int laserDamage;
    [SerializeField] float damageSpeed;
    [SerializeField] float SlowDownEnemy;
    [SerializeField] float slowDuration;
    [SerializeField] LayerMask enemyL;
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
        laser.SetPosition(1,DetectEnemy(targetEnemy));
        laser.enabled = true;
    }

    Vector3 DetectEnemy(Transform targetEnemy) 
    {
        RaycastHit[] hits = Physics.RaycastAll
        (transform.position,targetEnemy.position + Vector3.up * 0.5f - transform.position,100,enemyL);

        foreach (RaycastHit hit in hits) 
        {
            if (hit.transform == targetEnemy) 
            {
                return hit.point;
            }
        }
        return targetEnemy.position;
    }

    public void Hit(Transform targetEnemy) 
    {
        //Debug.Log("zZzZzZzZz");
        Enemy e = targetEnemy.parent.GetComponent<Enemy>();
        e.TakeDamage(laserDamage);
        e.Slow(SlowDownEnemy/100f, slowDuration);
    }
}
