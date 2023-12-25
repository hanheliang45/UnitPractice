using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ghost : MonoBehaviour
{
    [SerializeField] float ghostSpeed;
    [SerializeField] Hero hero;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Hero hero = collision.gameObject.GetComponent<Hero>();
        hero.Die();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 ghost = transform.position;
        Vector3 heroP = hero.transform.position;
        Vector3 direction = heroP - ghost;
        this.transform.position += Vector3.up * 5 * Time.deltaTime;
        //this.transform.position += direction.normalized * ghostSpeed * Time.deltaTime;
        this.transform.position += direction * ghostSpeed * Time.deltaTime;

        if (this.transform.position.x > Hero.instance.transform.position.x)
        {
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else 
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
