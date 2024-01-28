using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Floor : MonoBehaviour
{
    [SerializeField] Material WhenSelected;
    MeshRenderer meshRenderer;
    Material normalMaterial;
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
    }
    private void OnMouseExit() 
    {
        WeaponBuilder.instance.SetFloor(null);
        meshRenderer.material = normalMaterial;
    }
    public void SetWeapon(Transform weapon) 
    {
        this.weapon = weapon;
    }
    public Transform GetWeapon() 
    {
        return weapon; 
    }
}
