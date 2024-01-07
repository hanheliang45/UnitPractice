using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] Enemy enemy;   
    // Start is called before the first frame update
    void Start()
    {
        enemy.OnDamage += Enemy_OnDamage;    
    }

    private void Enemy_OnDamage(object sender, float e)
    {
        this.GetComponent<Image>().fillAmount = e;
    }
}
