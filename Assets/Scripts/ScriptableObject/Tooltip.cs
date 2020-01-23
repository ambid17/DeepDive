using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tooltip", menuName = "ScriptableObjects/Upgrades/Tooltip", order = 2)]
public class Tooltip : ScriptableObject
{
    public UpgradeType tooltipType;
}
