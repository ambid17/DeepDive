using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "LightBatteryUpgrades", menuName = "ScriptableObjects/Upgrades/LightBatteryUpgrades")]
public class LightBatteryUpgrades : ScriptableObject
{
    public List<MinimapUpgrade> lightBatteryUpgrades;
}

[Serializable]
public class LightBatteryUpgrade
{
    public int order;
    public int cost;
    public float duration;
    public string description;
}