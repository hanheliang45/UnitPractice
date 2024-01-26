using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WeaponBuilder : MonoBehaviour
{
    public event EventHandler OnSelection;

    public static WeaponBuilder instance;
    [SerializeField] List<WeaponSO> WeaponList;

    private Floor SelectedFloor;
    private WeaponSO selectedWeapon;
    private void Update()
    {
        if (selectedWeapon == null) 
        {
            return;
        }
        if (!Input.GetMouseButtonDown(0)) 
        {
            return;
        }
        Instantiate(selectedWeapon.Prefab, this.SelectedFloor.transform.position,Quaternion.identity);
    }

    private void Awake()
    {
        instance = this;    
    }
    public void SetFloor(Floor floor) 
    {
        SelectedFloor = floor;
    }
    public void SetWeapon(WeaponSO selectedWeapon) 
    {
        if (this.selectedWeapon == selectedWeapon) 
        {
            this.selectedWeapon = null;
        }
        else
        {
        this.selectedWeapon = selectedWeapon;
        }
        OnSelection?.Invoke(this, null);
    }
    public List<WeaponSO> GetWeaponList() 
    {
        return WeaponList;
    }
    public WeaponSO GetSelectedWeapon() 
    {
        return selectedWeapon;
    }
}
