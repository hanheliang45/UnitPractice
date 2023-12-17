using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Top : MonoBehaviour
{
    
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position - new Vector3(speed * Time.deltaTime, 0, 0);
        if (transform.position.x < -20)
        { 
            Destroy(gameObject);
        }
    }
    



}
