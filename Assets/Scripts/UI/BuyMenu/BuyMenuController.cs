using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyMenuController : MonoBehaviour
{
    public PlayerData playerData;
    public Upgrades upgrades;

    public Button drillUpgradeButton;
    public Button drillInfoButton;

    public Button hullUpgradeButton;
    public Button hullInfoButton;

    public Button lightSizeUpgradeButton;
    public Button lightSizeInfoButton;

    public Button lightBatteryUpgradeButton;
    public Button lightBatteryInfoButton;

    public Button minimapUpgradeButton;
    public Button minimapInfoButton;

    public UpgradeType upgradeType;

    public Tooltip tooltip;

    void OnEnable()
    {
        ClearListeners();
        AddListeners();
    }

    void ClearListeners()
    {
        drillUpgradeButton.onClick.RemoveAllListeners();
        drillInfoButton.onClick.RemoveAllListeners();

        hullUpgradeButton.onClick.RemoveAllListeners();
        hullInfoButton.onClick.RemoveAllListeners();

        lightSizeUpgradeButton.onClick.RemoveAllListeners();
        lightSizeInfoButton.onClick.RemoveAllListeners();

        lightBatteryUpgradeButton.onClick.RemoveAllListeners();
        lightBatteryInfoButton.onClick.RemoveAllListeners();

        minimapUpgradeButton.onClick.RemoveAllListeners();
        minimapInfoButton.onClick.RemoveAllListeners();
    }

    void AddListeners()
    {
        drillUpgradeButton.onClick.AddListener(() => Upgrade(UpgradeType.Drill));
        drillInfoButton.onClick.AddListener(() => ShowTooltip(UpgradeType.Drill));

        hullUpgradeButton.onClick.AddListener(() => Upgrade(UpgradeType.Hull));
        hullInfoButton.onClick.AddListener(() => ShowTooltip(UpgradeType.Hull));

        lightSizeUpgradeButton.onClick.AddListener(() => Upgrade(UpgradeType.LightSize));
        lightSizeInfoButton.onClick.AddListener(() => ShowTooltip(UpgradeType.LightSize));

        lightBatteryUpgradeButton.onClick.AddListener(() => Upgrade(UpgradeType.LightBattery));
        lightBatteryInfoButton.onClick.AddListener(() => ShowTooltip(UpgradeType.LightBattery));

        minimapUpgradeButton.onClick.AddListener(() => Upgrade(UpgradeType.MiniMap));
        minimapInfoButton.onClick.AddListener(() => ShowTooltip(UpgradeType.MiniMap));
    }

    void Upgrade(UpgradeType type)
    {
        if (CanUpgrade(type))
        {
            // take money from player
            playerData.money -= GetNextUpgradeCost(type);

            // add upgrade
            switch (type)
            {
                case UpgradeType.Drill:
                    playerData.upgradeStatus.drillUpgrade++;
                    break;
                case UpgradeType.Hull:
                    playerData.upgradeStatus.hullUpgrade++;
                    break;
                case UpgradeType.LightSize:
                    playerData.upgradeStatus.lightSizeUpgrade++;
                    break;
                case UpgradeType.LightBattery:
                    playerData.upgradeStatus.lightBatteryUpgrade++;
                    break;
                case UpgradeType.MiniMap:
                    playerData.upgradeStatus.minimapUpgrade++;
                    break;
            }
        }
    }

    bool CanUpgrade(UpgradeType type)
    {
        int cost = GetNextUpgradeCost(type);
        if (playerData.money >= cost)
        {
            return true;
        }
        return false;
    }

    int GetNextUpgradeCost(UpgradeType type)
    {
        int cost = 0;
        int upgradeNumber = 0;
        switch (type)
        {
            case UpgradeType.Drill:
                upgradeNumber = playerData.upgradeStatus.drillUpgrade;
                cost = upgrades.drillUpgrades.drillUpgrades[upgradeNumber + 1].cost;
                break;
            case UpgradeType.Hull:
                upgradeNumber = playerData.upgradeStatus.hullUpgrade;
                cost = upgrades.hullUpgrades.hullUpgrades[upgradeNumber + 1].cost;
                break;
            case UpgradeType.LightSize:
                upgradeNumber = playerData.upgradeStatus.lightSizeUpgrade;
                cost = upgrades.lightSizeUpgrades.lightSizeUpgrades[upgradeNumber + 1].cost;
                break;
            case UpgradeType.LightBattery:
                upgradeNumber = playerData.upgradeStatus.lightBatteryUpgrade;
                cost = upgrades.lightBatteryUpgrades.lightBatteryUpgrades[upgradeNumber + 1].cost;
                break;
            case UpgradeType.MiniMap:
                upgradeNumber = playerData.upgradeStatus.minimapUpgrade;
                cost = upgrades.minimapUpgrades.minimapUpgrades[upgradeNumber + 1].cost;
                break;
        }

        return cost;
    }

    public void ShowTooltip(UpgradeType type)
    {
        tooltip.tooltipType = type;
    }
}
