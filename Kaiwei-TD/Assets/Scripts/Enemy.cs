using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int targetid = 0;
    [SerializeField] float moveSpeed;
    [SerializeField] Transform wayPoints;
    private List<Transform> WayPointList; 
    private void Start()
    {
        WayPointList = new List<Transform>();
        foreach (Transform t in wayPoints)
        { 
            WayPointList.Add(t);
        }

    }
    void Update()
    {
        this.MoveTo(WayPointList[targetid]);
        
    }
    void MoveTo(Transform target) 
    {
        Vector3 targetPosition = target.position;
        Vector3 MyPosition = this.transform.position;
        Vector3 direction = (targetPosition - MyPosition).normalized;
        this.transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
