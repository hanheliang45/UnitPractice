using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    void Start()
    {
        this.gameObject.SetActive(false);
        this.transform.parent.GetComponent<Enemy>().OnDamage += HealthBar_OnDamage;

    }

    private void HealthBar_OnDamage(object sender, float e) 
    {
        this.gameObject.SetActive(true);
    }
}
