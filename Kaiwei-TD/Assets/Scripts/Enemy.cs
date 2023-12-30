using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int targetid = 0;
    [SerializeField] float moveSpeed;
    
    private List<Transform> WayPointList; 
    private void Start()
    {
        WayPointList = new List<Transform>();
        foreach (Transform t in WayPoints.instance.transform)
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
        Vector3 realDirection = targetPosition - MyPosition;
        
        Vector3 myPositionOnFloor = new Vector3(MyPosition.x,targetPosition.y,MyPosition.z);
        Vector3 direction = new Vector3(realDirection.x, 0, realDirection.z).normalized;
        this.transform.position += direction * moveSpeed * Time.deltaTime;

        if (Vector3.Distance(targetPosition, myPositionOnFloor) < 0.05)
        {
            targetid = targetid + 1;
            if (targetid == WayPointList.Count) 
            {
                Destroy(this.gameObject);
                Debug.Log("!!!!!");
            }
        }
    }
}
