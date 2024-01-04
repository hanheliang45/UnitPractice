using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed; 
    [SerializeField] Transform enemy;
    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy == null) { return;     }
        Vector3 enemyP = enemy.position;
        Vector3 Myposition = this.transform.position;
        Vector3 direction = (enemyP-Myposition).normalized;
        this.transform.position += direction * bulletSpeed*Time.deltaTime;

        if (Vector3.Distance(Myposition, enemyP) <= 0.05)
        {
            Debug.Log("HIT!!!");
            Destroy(this.gameObject);
        }
        
    }
    public void SetEnemy(Transform e)
    {
        enemy=e;
    }

}
