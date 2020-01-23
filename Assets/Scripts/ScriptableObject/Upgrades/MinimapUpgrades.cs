using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "MinimapUpgrades", menuName = "ScriptableObjects/Upgrades/MinimapUpgrades")]
public class MinimapUpgrades : ScriptableObject
{
    public List<MinimapUpgrade> minimapUpgrades;
}

[Serializable]
public class MinimapUpgrade
{
    public int order;
    public int cost;
    public string description;
}
