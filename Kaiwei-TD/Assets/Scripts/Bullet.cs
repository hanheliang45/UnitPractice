using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed; 
    [SerializeField] int bulletDamage;
    [SerializeField] bool IsMissle;
    [SerializeField] float explosionRange;
    [SerializeField] int inExplosionDamage;
    [SerializeField] LayerMask enemyLayer;
    Transform enemy;
    // Start is called before the first frame update
    void Start()
    {
                
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy == null) 
        {
            Destroy(this.gameObject);
        }
        if (enemy == null) { return;     }
        Vector3 enemyP = enemy.position;
        Vector3 Myposition = this.transform.position;
        Vector3 direction = (enemyP-Myposition).normalized;
        this.transform.position += direction * bulletSpeed*Time.deltaTime;

        this.transform.forward = direction;

        if (Vector3.Distance(Myposition, enemyP) <= 0.05)
        {
            Destroy(this.gameObject);
            if (IsMissle) 
            {
                Collider[] InExplosion = Physics.OverlapSphere(transform.position,explosionRange,enemyLayer);
                foreach (Collider enemy in InExplosion) 
                {
                    enemy.transform.parent.GetComponent<Enemy>().TakeDamage(inExplosionDamage);
                }
                return;
            }
            enemy.parent.GetComponent<Enemy>().TakeDamage(bulletDamage);
        }
        
    }
    public void SetEnemy(Transform e)
    {
        enemy=e;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRange);
    }
}
