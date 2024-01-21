using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] Transform gun;
    [SerializeField] Transform missle;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y)) 
        {
            WeaponBuilder.instance.SetWeapon(gun);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            WeaponBuilder.instance.SetWeapon(missle );
        }
    }
}
