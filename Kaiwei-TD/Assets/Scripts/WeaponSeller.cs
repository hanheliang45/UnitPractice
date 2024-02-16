using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponSeller : MonoBehaviour
{
    public static WeaponSeller instance;
    public Floor underPointer;
    [SerializeField] private Transform panel;
    
    void Awake()
    {
        instance = this;    
    }

    void Update()
    {
        if (!Input.GetMouseButtonDown(0)) 
        {
            return;
        }
        if (underPointer == null) 
        {
            return;
        }
        if (underPointer.GetWeapon() == null) 
        {
            return;
        }

        panel.transform.position = underPointer.GetWeapon().position + Vector3.up*2;
        Debug.Log("Sellable :)");
        SellButton.instance.SetFloor(underPointer);
        
    }

    public void SetUnderPointerFloor(Floor underPointer) 
    {
        this.underPointer = underPointer;
    }
}
