using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Middle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bird bird = collision.GetComponent<Bird>();
        bird?.addScore();
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
