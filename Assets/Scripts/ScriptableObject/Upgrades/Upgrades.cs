using UnityEngine;

public enum UpgradeType
{
    Drill, Hull, LightSize, LightBattery, MiniMap
}

[CreateAssetMenu(fileName = "Upgrades", menuName = "ScriptableObjects/Upgrades/Upgrades", order = 2)]
public class Upgrades : ScriptableObject
{
    public DrillUpgrades drillUpgrades;
    public HullUpgrades hullUpgrades;
    public LightSizeUpgrades lightSizeUpgrades;
    public LightBatteryUpgrades lightBatteryUpgrades;
    public MinimapUpgrades minimapUpgrades;
}