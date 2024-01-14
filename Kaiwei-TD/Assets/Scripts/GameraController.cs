using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameraController : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cinemachine;
    private CinemachineTransposer t;
    // Start is called before the first frame update
    void Start()
    {
        t = cinemachine.GetCinemachineComponent<CinemachineTransposer>();        
    }

    // Update is called once per frame
    void Update()
    {
        this.Move();
        this.Zoom();
    }
    private void Move() 
    {
        Vector3 MoveDirection = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.z <= 20) 
        {
            MoveDirection += new Vector3(0, 0, 1) ;
        }
        if (Input.GetKey(KeyCode.DownArrow) && transform.position.z >= -15)
        {
            MoveDirection += new Vector3(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x <= 20)
        {
            MoveDirection += new Vector3(1, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x >= -20)
        {
            MoveDirection += new Vector3(-1, 0, 0);
        }
        int MoveSpeed = 20;
        this.transform.position += MoveDirection * MoveSpeed * Time.deltaTime;
    }
    public void Zoom() 
    {
        float scroll = -Input.mouseScrollDelta.y;
        Vector3 ZoomDirection = new Vector3(0, scroll * 3, -scroll);
        t.m_FollowOffset += ZoomDirection * Time.deltaTime * 50;
    }
}
