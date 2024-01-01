using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] float range;
    [SerializeField] LayerMask enemyLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.Aim();    
    }
    private void Aim() 
    {
        Collider[] colliderList = Physics.OverlapSphere(transform.position, range,enemyLayer);
        foreach (Collider i in colliderList)
        {
            Debug.Log(colliderList.Length);    
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
