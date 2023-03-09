using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ebac.Core.Singleton;
using UnityEngine.UI;

public class UiInGameManager : Singleton<UiInGameManager>
{
    public TextMeshProUGUI uiTextCoins;
    public Image uiLifePlayerBar;

    public static void UpdateTextCoins(string s)
    {
       Instance.uiTextCoins.text = s;
    }
    public static void UpdateLifeBar(Image i)
    {
        Instance.uiLifePlayerBar = i;
    }
}
