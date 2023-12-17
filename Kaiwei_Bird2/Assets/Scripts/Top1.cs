using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class top1 : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bird bird = collision.gameObject.GetComponent<Bird>();
        bird.killMe();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
