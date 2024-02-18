using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WeaponBuilder : MonoBehaviour
{
    public event EventHandler OnSelection;
    
    public static WeaponBuilder instance;
    [SerializeField] List<WeaponSO> WeaponList;
    private Floor selectedFloor;
    private WeaponSO selectedWeapon;
    private void Update()
    {
        
        if (selectedWeapon == null) 
        {
            return;
        }
        if (selectedFloor == null) 
        {
            return;
        }
        if (selectedFloor.GetWeapon() != null) 
        {
            return;
        }
        if (EventSystem.current.IsPointerOverGameObject()) 
        {
            return;
        }
        if (!Input.GetMouseButtonDown(0)) 
        {
            return;
        }
        int goldNeeded = this.selectedWeapon.goldNeededToBuild;
        if (ResourceManager.instance.GetGold() < goldNeeded)
        {
            return;
        }
        ResourceManager.instance.SpendGold(goldNeeded);
        Transform newWeapon = Instantiate(selectedWeapon.Prefab, this.selectedFloor.transform.position,Quaternion.identity);
        selectedFloor.SetWeapon(newWeapon);
        selectedFloor.SetWeaponType_2(selectedWeapon);
    }
    
    private void Awake()
    {
        instance = this;    
    }
    public void SetFloor(Floor floor) 
    {
        selectedFloor = floor;
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
