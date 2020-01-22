using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MiningStats", menuName = "ScriptableObjects/MiningStats", order = 2)]
public class MiningStats : ScriptableObject
{
    public List<TileStatsData> tileStats;
}

public enum TileType
{
    Dirt, Bronze, Iron
}

public class TileStatsData
{
    public TileType tileType;
    public int numberMined;
}
