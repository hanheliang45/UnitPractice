using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponSeller : MonoBehaviour
{
    public static WeaponSeller instance;
    [SerializeField] private Transform panel;
    public Floor underPointer;
    Transform weapon;
    
    void Awake()
    {
        instance = this;    
    }

    private void Start()
    {
        panel.gameObject.SetActive(false);
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
        panel.gameObject.SetActive(true);
    }

    public void SetUnderPointerFloor(Floor underPointer) 
    {
        this.underPointer = underPointer;
    }



}
