﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 2)]
public class PlayerData : ScriptableObject
{
    public float money;
    public float hp;
    public UpgradeStatus upgradeStatus;
    public MiningStats miningStats;
    public int[,] pathFollowed;
}
