using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public PlayerData playerData;
    public PlayerData defaultPlayerData;

    private const string hpPreferenceName = "hp";
    private const string moneyPreferenceName = "money";

    void Start()
    {
        playerData.hp = PlayerPrefs.GetFloat(hpPreferenceName, defaultPlayerData.hp);
        playerData.money = PlayerPrefs.GetFloat(moneyPreferenceName, defaultPlayerData.money);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat(hpPreferenceName, playerData.hp);
        PlayerPrefs.SetFloat(moneyPreferenceName, playerData.money);
    }
}
