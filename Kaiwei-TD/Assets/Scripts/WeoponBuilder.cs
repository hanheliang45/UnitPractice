using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeoponBuilder : MonoBehaviour
{
    public static WeoponBuilder instance;
    [SerializeField] Transform gun;
    private Floor SelectedFloor;
    void Start()
    {
        
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
