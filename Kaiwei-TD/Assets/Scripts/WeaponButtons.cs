using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponButtons : MonoBehaviour
{
    Dictionary<WeaponSO, Transform> weaponToButton;
    void Start()
    {
        weaponToButton = new Dictionary<WeaponSO,Transform>();
        Transform ButtonTemplate = transform.Find("WeaponButton"); 
        
        foreach (WeaponSO weaponType in WeaponBuilder.instance.GetWeaponList())
        {
            Transform newButton = Instantiate(ButtonTemplate, this.transform);
            newButton.Find("WeaponCost").GetComponent<TextMeshProUGUI>().text = weaponType.goldNeededToBuild.ToString();
            newButton.Find("Image").GetComponent<Image>().sprite = weaponType.sprite;
            newButton.GetComponent<Button>().onClick.AddListener
            (() => {
            WeaponBuilder.instance.SetWeapon(weaponType);
            //newButton.Find("WhenSelected").gameObject.SetActive(true);
            });
            weaponToButton[weaponType] = newButton;
            WeaponBuilder.instance.OnSelection += WeaponBuilder_OnSelection;
        }
        ButtonTemplate.gameObject.SetActive(false);
    }

    private void WeaponBuilder_OnSelection(object sender, System.EventArgs e)
    {
        foreach (WeaponSO weaponSO in weaponToButton.Keys) 
        {
            bool setTrue = WeaponBuilder.instance.GetSelectedWeapon() == weaponSO;
            weaponToButton[weaponSO].Find("WhenSelected").gameObject.SetActive(setTrue);
        }
        //foreach (Transform ButtonOutline in this.transform) 
        
        //    ButtonOutline.Find("WhenSelected").gameObject.SetActive(false);
        //}    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
