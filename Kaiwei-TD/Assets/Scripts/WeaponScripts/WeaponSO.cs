using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu()]
public class WeaponSO : ScriptableObject
{
    public Transform Prefab;
    public Sprite sprite;
    public string Name;
    public int goldNeededToBuild;
}
