using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyTracker : MonoBehaviour
{
    public PlayerData playerData;
    public Text myText;

    void Start()
    {
        
    }

    void Update()
    {
        myText.text = "$" + playerData.money.ToString();
    }
}
