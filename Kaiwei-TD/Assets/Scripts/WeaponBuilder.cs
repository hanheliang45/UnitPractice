using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBuilder : MonoBehaviour
{
    public static WeaponBuilder instance;
    [SerializeField] Transform gun;
    private Floor SelectedFloor;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Instantiate(gun,this.SelectedFloor.transform.position,Quaternion.identity);
        }
    }

    private void Awake()
    {
        instance = this;    
    }
    public void SetFloor(Floor floor) 
    {
        SelectedFloor = floor;
    }
}
