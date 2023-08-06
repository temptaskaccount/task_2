using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
   
    public UIGameEnd UIGameEnd;

    private void Start()
    {
        GamePlayManager.instance.OnLevelSuccess += OnLevelComplete;
        GamePlayManager.instance.OnLevelFail += OnLevelFail;
    }

    public void OnLevelComplete()
    {
        UIGameEnd.Initilaize(true);
    }
    public void OnLevelFail()
    {
        UIGameEnd.Initilaize(false);
    }

    private void OnDestroy()
    {
        GamePlayManager.instance.OnLevelSuccess -= OnLevelComplete;
    }
}
