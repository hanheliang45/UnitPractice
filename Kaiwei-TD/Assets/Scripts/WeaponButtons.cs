using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponButtons : MonoBehaviour
{
    
    void Start()
    {
        Transform ButtonTemplate = transform.Find("WeaponButton"); 
        
        foreach (WeaponSO weaponType in WeaponBuilder.instance.GetWeaponList())
        {
            Transform newButton = Instantiate(ButtonTemplate, this.transform);
            newButton.Find("Image").GetComponent<Image>().sprite = weaponType.sprite;
            newButton.GetComponent<Button>().onClick.AddListener
            (() => { WeaponBuilder.instance.SetWeapon(weaponType.Prefab); });
        }
        ButtonTemplate.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
