using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RestartButtonAwaker : MonoBehaviour
{
    [SerializeField] Button restartButton; 
    // Start is called before the first frame update
    void Start()
    {
        Hero.instance.OnKill += Instance_OnKill; 
    }

    private void Instance_OnKill(object sender, System.EventArgs e)
    {
        restartButton.gameObject.SetActive(true); 
    }





    // Update is called once per frame
    void Update()
    {
        
    }
}
