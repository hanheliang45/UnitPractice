using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Floor : MonoBehaviour
{
    [SerializeField] Material WhenSelected;
    MeshRenderer meshRenderer;
    Material normalMaterial;
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
        meshRenderer.material = normalMaterial;
    }
}
