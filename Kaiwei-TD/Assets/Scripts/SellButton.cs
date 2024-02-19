using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellButton : MonoBehaviour
{
    public static SellButton instance;
    [SerializeField] private int GoldGotBackPercent;
    [SerializeField] private Transform panel;
    private WeaponSO weaponType;
    public Floor floor;
    Transform weapon;




    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
               
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void Sell()
    {
        
        if (floor == null) { return; }
        Destroy(floor.GetWeapon().gameObject);
        floor.Clear();
        ResourceManager.instance.EarnGold(
            weapon.GetComponent<WeaponIndentifer>().GetWeaponType().goldNeededToBuild*(GoldGotBackPercent/100)
            ); 
        floor = null;
        panel.gameObject.SetActive( false );

    }

    public void SetWeaponType(WeaponSO weaponType)
    {
        this.weaponType = weaponType;
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
