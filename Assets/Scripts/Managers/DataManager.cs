using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager 
{
    public static int LevelIndex
    {
        get => PlayerPrefs.GetInt("LevelIndexKey", 0);
        set => PlayerPrefs.SetInt("LevelIndexKey", value);
    }

    public static Action OnCurrencyUpdate;
    public static int Currency
    {
        get => PlayerPrefs.GetInt("CurrencyKey", 0);
        set
        {
            PlayerPrefs.SetInt("CurrencyKey", value);
            OnCurrencyUpdate?.Invoke();
        }

    } 
}
