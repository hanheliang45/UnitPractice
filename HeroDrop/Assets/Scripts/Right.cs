using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Hero hero = collision.gameObject.GetComponent<Hero>();
        hero.Sprinting();
    }
    // Update is called once per frame
    void Update()
    {
            
    }
}
