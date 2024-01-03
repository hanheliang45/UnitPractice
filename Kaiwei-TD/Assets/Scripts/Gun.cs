using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class Gun : MonoBehaviour
{
    [SerializeField] float range;
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] float aimSpeed;
    private Transform targetEnemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.Aim();
        this.Aiming();
    }
    private void Aiming() 
    {
        if (this.targetEnemy == null) 
        {
            return;
        }
        Vector3 direction = targetEnemy.transform.position-this.transform.position;
        //transform.forward = direction; 
        Vector3 directionSmooth = Vector3.Lerp(transform.forward, direction, aimSpeed * Time.deltaTime  );
        transform.forward = directionSmooth;
    }
    private void Aim() 
    {
        targetEnemy = null;
        Collider[] colliderList = Physics.OverlapSphere(transform.position, range,enemyLayer);
        float nearest = float.MaxValue;
                                                    
        foreach (Collider collider in colliderList)
        {
            float newEnemy = Vector3.Distance(transform.position, collider.transform.position);
            if (newEnemy < nearest) 
            {
                targetEnemy = collider.transform;
                nearest = newEnemy;
            }
            
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    public Transform GetEnemy() 
    {
        return this.targetEnemy;
    }
}
