using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Middle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Hero hero = collision.gameObject.GetComponent<Hero>();
        hero.AddScore();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
