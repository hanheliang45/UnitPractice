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

    public int GetGold()
    {
        return gold;
    }

    public void EarnGold(int earnedGold) 
    {
        gold += earnedGold;
        Debug.Log(gold);
        OnEarnGold?.Invoke(this,gold);
    }

    public void SpendGold(int goldNeeded) 
    {
        gold -= goldNeeded;
        OnEarnGold?.Invoke(this, gold);
    }
}
