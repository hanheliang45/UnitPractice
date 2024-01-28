using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldAmount : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        ResourceManager.instance.OnEarnGold += Instance_OnEarnGold;    
    }

    private void Instance_OnEarnGold(object sender, int e)
    {
        textMesh.text = e.ToString();    
    }
}
