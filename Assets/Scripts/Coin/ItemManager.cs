using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ebac.Core.Singleton;
using UnityEngine.UI;

public class ItemManager : Singleton<ItemManager>
{
    public SOInt coins;
    public Image uiLifePlayerBar;
    public TextMeshProUGUI uiTextCoins;

    private void Start()
    {
        Reset();
    }


    private void Reset()
    {
        coins.value = 0;
        uiLifePlayerBar = null;
        UpdateUI();
    }

    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        //uiTextCoins.text = coins.ToString();
        //UiInGameManager.UpdateTextCoins(coins.value.ToString());
    }
}
