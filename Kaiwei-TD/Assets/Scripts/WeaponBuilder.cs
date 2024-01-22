using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBuilder : MonoBehaviour
{
    public static WeaponBuilder instance;
    [SerializeField] List<WeaponSO> WeaponList;

    private Floor SelectedFloor;
    private Transform SelectedWeapon;
    private void Update()
    {
        if (SelectedWeapon == null) 
        {
            return;
        }
        if (!Input.GetMouseButtonDown(0)) 
        {
            return;
        }
        Instantiate(SelectedWeapon, this.SelectedFloor.transform.position,Quaternion.identity);
    }

    private void Awake()
    {
        instance = this;    
    }
    public void SetFloor(Floor floor) 
    {
        SelectedFloor = floor;
    }
    public void SetWeapon(Transform selectedWeapon) 
    {
        SelectedWeapon = selectedWeapon;
    }
}
