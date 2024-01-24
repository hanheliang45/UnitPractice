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
            (() => {
            newButton.Find("WhenSelected").gameObject.SetActive(true);
            WeaponBuilder.instance.SetWeapon(weaponType.Prefab); });

            WeaponBuilder.instance.OnSelection += WeaponBuilder_OnSelection;
        }
        ButtonTemplate.gameObject.SetActive(false);
    }

    private void WeaponBuilder_OnSelection(object sender, System.EventArgs e)
    {
        foreach (Transform ButtonOutline in this.transform) 
        {
            ButtonOutline.Find("WhenSelected").gameObject.SetActive(false);
        }    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
