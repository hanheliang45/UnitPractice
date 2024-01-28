using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager instance;
    public event EventHandler<int> OnEarnGold;
    [SerializeField] int gold;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void EarnGold(int earnedGold) 
    {
        gold += earnedGold;
        Debug.Log(gold);
        OnEarnGold?.Invoke(this,gold);
    }
}
