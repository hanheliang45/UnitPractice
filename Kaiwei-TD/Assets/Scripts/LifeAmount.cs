using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LifeAmount : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    void Start()
    {
        LifeManager.instance.OnLoseLife += LifeManager_OnLoseLife;

        textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void LifeManager_OnLoseLife(object sender, int e)
    {
        textMesh.text = e.ToString();    
    }
}
