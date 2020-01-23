using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUIManager : MonoBehaviour
{
    public PlayerData playerData;
    public Upgrades upgrades;
    public Text numberOfUpgradesText;
    public Text nextUpgradeCostText;
    public UpgradeType upgradeToManage;

    void Update()
    {
        UpdateUpgradeUI();
    }

    private void UpdateUpgradeUI()
    {
        int numberOfUpgrades = 0;
        switch (upgradeToManage)
        {
            case UpgradeType.Drill:
                numberOfUpgrades = playerData.upgradeStatus.drillUpgrade;
                numberOfUpgradesText.text = numberOfUpgrades.ToString();
                nextUpgradeCostText.text = "$" + upgrades.drillUpgrades.drillUpgrades[numberOfUpgrades + 1].cost.ToString();
                break;
            case UpgradeType.Hull:
                numberOfUpgrades = playerData.upgradeStatus.hullUpgrade;
                numberOfUpgradesText.text = numberOfUpgrades.ToString();
                nextUpgradeCostText.text = "$" + upgrades.hullUpgrades.hullUpgrades[numberOfUpgrades + 1].cost.ToString();
                break;
            case UpgradeType.LightSize:
                numberOfUpgrades = playerData.upgradeStatus.lightSizeUpgrade;
                numberOfUpgradesText.text = numberOfUpgrades.ToString();
                nextUpgradeCostText.text = "$" + upgrades.lightSizeUpgrades.lightSizeUpgrades[numberOfUpgrades + 1].cost.ToString();
                break;
            case UpgradeType.LightBattery:
                numberOfUpgrades = playerData.upgradeStatus.lightBatteryUpgrade;
                numberOfUpgradesText.text = numberOfUpgrades.ToString();
                nextUpgradeCostText.text = "$" + upgrades.lightBatteryUpgrades.lightBatteryUpgrades[numberOfUpgrades + 1].cost.ToString();
                break;
            case UpgradeType.MiniMap:
                numberOfUpgrades = playerData.upgradeStatus.minimapUpgrade;
                numberOfUpgradesText.text = numberOfUpgrades.ToString();
                nextUpgradeCostText.text = "$" + upgrades.minimapUpgrades.minimapUpgrades[numberOfUpgrades + 1].cost.ToString();
                break;
        }
    }
}
