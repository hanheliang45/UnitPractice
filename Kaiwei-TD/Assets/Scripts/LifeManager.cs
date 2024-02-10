using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public static LifeManager instance;
    public event EventHandler OnLose;
    public event EventHandler<int> OnLoseLife;
    [SerializeField] int Life;

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

    public void LoseLife()
    {
        Life--;
        OnLoseLife?.Invoke(this,Life);
        if (Life == 0) 
        {
            Debug.Log("Fail =<-.->=");
            Time.timeScale = 0;
            OnLose?.Invoke(this,null);
        }
    }
}
