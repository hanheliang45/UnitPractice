using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpGradeButton : MonoBehaviour
{
    public static UpGradeButton instance;

    private void Awake()
    {
        instance = this; 
    }
    Transform weapon;
    Floor floor;

    public void UpGrade() 
    {
        if (floor.GetWeapon() == null)
        {
            return;     
        }
        Debug.Log("Clicked");
        floor.GetWeapon().GetComponent<WeaponUpGrade>().UpGrade();
    }

    public void SetFloor(Floor floor)
    {
        this.floor = floor;
    }

    public void SetWeapon(Transform weapon)
    {
        this.weapon = weapon;
    }
}
