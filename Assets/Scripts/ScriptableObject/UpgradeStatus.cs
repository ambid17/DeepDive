using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeStatus", menuName = "ScriptableObjects/Upgrades/UpgradeStatus", order = 2)]
public class UpgradeStatus : ScriptableObject
{
    public DrillUpgrade drillUpgrade;
    public HullUpgrade hullUpgrade;
    public LightSizeUpgrade lightSizeUpgrade;
    public LightBatteryUpgrade lightBatteryUpgrade;
    public MinimapUpgrade minimapUpgrade;
}
