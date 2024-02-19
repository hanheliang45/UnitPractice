using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpGrade : MonoBehaviour
{
    public static WeaponUpGrade instance;
    private bool UpGraded;
    public void Awake()
    {
        instance = this;
    }

    // [SerializeField] private WeaponSO weaponType;
    [SerializeField] private Transform template;
    public void UpGrade()
    {
        Debug.Log("UpGrading");
        if (UpGraded)
        {
            return;    
        }
        Instantiate(template, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        UpGraded = true;
    }


}
