﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "Tile", menuName = "ScriptableObjects/Tile", order = 1)]
public class CustomTile : Tile
{
    [Tooltip("Unique tile id")]
    public int tileId;
    [Tooltip("Depth you can start finding this mineral")]
    public int findableDepth;
    [Tooltip("Depth you can stop finding this mineral")]
    public int lastFindableDepth;
    [Tooltip("Used in map generation for spawn rate")]
    public float rarity;
    [Tooltip("How much money the player is awarded for this tile")]
    public float value;
    [Tooltip("How long this block takes to mine")]
    public float miningSpeed;
}
