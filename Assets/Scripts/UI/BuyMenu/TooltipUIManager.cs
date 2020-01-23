using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipUIManager : MonoBehaviour
{
    public Tooltip tooltip;
    public Text tooltipText;
    public Upgrades upgrades;
    public PlayerData playerData;

    void Update()
    {
        tooltipText.text = GetTooltipText();
    }

    private string GetTooltipText()
    {
        string toReturn = "";
        int currentUpgrade = 0;
        switch (tooltip.tooltipType)
        {
            case UpgradeType.Drill:
                currentUpgrade = playerData.upgradeStatus.drillUpgrade;
                toReturn = upgrades.drillUpgrades.drillUpgrades[currentUpgrade + 1].description;
                break;
            case UpgradeType.Hull:
                currentUpgrade = playerData.upgradeStatus.hullUpgrade;
                toReturn = upgrades.hullUpgrades.hullUpgrades[currentUpgrade + 1].description;
                break;
            case UpgradeType.LightSize:
                currentUpgrade = playerData.upgradeStatus.lightSizeUpgrade;
                toReturn = upgrades.lightSizeUpgrades.lightSizeUpgrades[currentUpgrade + 1].description;
                break;
            case UpgradeType.LightBattery:
                currentUpgrade = playerData.upgradeStatus.lightBatteryUpgrade;
                toReturn = upgrades.lightBatteryUpgrades.lightBatteryUpgrades[currentUpgrade + 1].description;
                break;
            case UpgradeType.MiniMap:
                currentUpgrade = playerData.upgradeStatus.minimapUpgrade;
                toReturn = upgrades.minimapUpgrades.minimapUpgrades[currentUpgrade + 1].description;
                break;
        }
        return toReturn;
    }
}
