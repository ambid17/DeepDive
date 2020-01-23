using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "HullUpgrades", menuName = "ScriptableObjects/Upgrades/HullUpgrades")]
public class HullUpgrades : ScriptableObject
{
    public List<MinimapUpgrade> hullUpgrades;
}

[Serializable]
public class HullUpgrade
{
    public int order;
    public int cost;
    public float hp;
    public string description;
}