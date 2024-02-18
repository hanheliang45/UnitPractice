using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponIndentifer : MonoBehaviour
{

    [SerializeField] WeaponSO weaponType;

    public WeaponSO GetWeaponType()
    {
        return weaponType;
    }
}
