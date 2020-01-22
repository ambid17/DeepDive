using UnityEngine;

public enum UpgradeType
{
    Drill, Hull, LightSize, LightBattery, MiniMap
}

[CreateAssetMenu(fileName = "UpgradeStatus", menuName = "ScriptableObjects/Upgrades/UpgradeStatus", order = 2)]
public class UpgradeStatus : ScriptableObject
{
    public DrillUpgrades drillUpgrades;
    public HullUpgrades hullUpgrades;
    public LightSizeUpgrades lightSizeUpgrades;
    public LightBatteryUpgrades lightBatteryUpgrades;
    public MinimapUpgrades minimapUpgrades;
}