using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
        meshRenderer.material = WhenSelected;
        WeaponBuilder.instance.SetFloor(this);
        WeaponSeller.instance.SetUnderPointerFloor(this);
        
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
    
}
