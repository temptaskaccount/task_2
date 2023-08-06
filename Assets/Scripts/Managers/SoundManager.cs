using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
     
    #region Instance
    
    public static SoundManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;
    }
    #endregion

    private void Start()
    {
        GamePlayManager.instance.OnLevelSuccess += ResetCombo;
    }

    public AudioSource source;
    public void ResetCombo()
    {
        comboCount = 0;
    }

    int comboCount = 0;
    public void SuccesPlatform()
    {
        source.pitch = 1 + comboCount * 0.1f;
        source.Play();
        comboCount++;
    }

    private void OnDestroy()
    {
        GamePlayManager.instance.OnLevelSuccess -= ResetCombo;
    }
}
