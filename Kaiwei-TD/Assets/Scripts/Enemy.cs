using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 4;

    void Update()
    {
        //this.transform.position += { direction} moveSpeed * Time.deltaTime;
    }
}
