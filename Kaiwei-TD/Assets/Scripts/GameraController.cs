using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameraController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.Move();    
    }
    private void Move() 
    {
        Vector3 MoveDirection = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.UpArrow)) 
        {
            MoveDirection += new Vector3(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            MoveDirection += new Vector3(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveDirection += new Vector3(1, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoveDirection += new Vector3(-1, 0, 0);
        }
        int MoveSpeed = 20;
        this.transform.position += MoveDirection * MoveSpeed * Time.deltaTime;
    } 
}
