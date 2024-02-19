using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;


public class Floor : MonoBehaviour
{
    [SerializeField] Material WhenSelected;
    MeshRenderer meshRenderer;
    Material normalMaterial; 
    WeaponSO weaponType;
    Transform weapon;
    
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        normalMaterial = meshRenderer.material;
    }
    private void OnMouseEnter()
    {
       
        UpGradeButton.instance.SetWeapon(weapon);
        SellButton.instance.SetWeapon(weapon);
        meshRenderer.material = WhenSelected;
        WeaponBuilder.instance.SetFloor(this);
        WeaponSeller.instance.SetUnderPointerFloor(this);
        if (EventSystem.current.IsPointerOverGameObject())
        {
            UpGradeButton.instance.SetWeapon(weapon);    
        }
    }
    private void OnMouseExit() 
    {
       
        WeaponBuilder.instance.SetFloor(null);
        meshRenderer.material = normalMaterial;
        WeaponSeller.instance.SetUnderPointerFloor(null);
    }
    public void SetWeapon(Transform weapon) 
    {
        this.weapon = weapon;
    }
    public Transform GetWeapon() 
    {
        return weapon; 
    }

    public void SetWeaponType(WeaponSO weaponType)
    {
        SellButton.instance.SetWeaponType(weaponType);    
    }

    public void Clear() 
    {
        weapon = null;
        weaponType = null;
    }

    public void SetWeaponType_2(WeaponSO weaponType) 
    {
        this.weaponType = weaponType;
    }


}
