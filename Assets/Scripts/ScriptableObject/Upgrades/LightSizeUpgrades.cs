using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "LightSizeUpgrades", menuName = "ScriptableObjects/Upgrades/LightSizeUpgrades")]
public class LightSizeUpgrades : ScriptableObject
{
    public List<MinimapUpgrade> lightSizeUpgrades;
}

[Serializable]
public class LightSizeUpgrade
{
    public int order;
    public int cost;
    public float radius;
    public string description;
}