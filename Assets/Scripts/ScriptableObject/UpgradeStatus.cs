using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeStatus", menuName = "ScriptableObjects/Upgrades/UpgradeStatus", order = 2)]
public class UpgradeStatus : ScriptableObject
{
    public int drillUpgrade;
    public int hullUpgrade;
    public int lightSizeUpgrade;
    public int lightBatteryUpgrade;
    public int minimapUpgrade;
}
