using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class Aiming : MonoBehaviour
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
        //this.Aim();
        this.Rotating();
        this.Aim2();
    }
    private void Rotating() 
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
        //targetEnemy = null;
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
    private void Aim2() 
    {
        if (targetEnemy == null) 
        {
            this.Aim();
        }
        if (targetEnemy == null) 
        {
            return;
        }
        if (Vector3.Distance(targetEnemy.transform.position,transform.position)>range) 
        {
            targetEnemy = null;
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
