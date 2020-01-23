using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "DrillUpgrades", menuName = "ScriptableObjects/Upgrades/DrillUpgrades")]
public class DrillUpgrades : ScriptableObject
{
    public List<DrillUpgrade> drillUpgrades;
}

[Serializable]
public class DrillUpgrade
{
    public int order;
    public int cost;
    public float effectiveness;
    public string description;
}
