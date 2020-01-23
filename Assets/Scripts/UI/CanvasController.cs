using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public GameObject inGameUI;
    public GameObject shopUI;

    void Start()
    {
        if(inGameUI == null)
        {
            Debug.LogError("No in game UI found");
        }

        if (shopUI == null)
        {
            Debug.LogError("No in shop UI found");
        }

        InitializeUI();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleGamePause();
            ToggleGameUI();
        }
    }

    void InitializeUI()
    {
        inGameUI.SetActive(true);
        shopUI.SetActive(false);
    }

    void ToggleGamePause()
    {
        Time.timeScale = Time.timeScale == 0f ? 1 : 0;
    }

    void ToggleGameUI()
    {
        inGameUI.SetActive(!inGameUI.activeInHierarchy);
        shopUI.SetActive(!shopUI.activeInHierarchy);
    }
}
