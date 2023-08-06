using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GamePlayManager : MonoBehaviour
{
    
     
    #region Instance
    
    public static GamePlayManager instance;

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
    
    public UnityAction OnLevelSuccess;
    public UnityAction OmLevelStart;
    public UnityAction OnLevelFail;

    public void LevelStart()
    {
        OmLevelStart?.Invoke();
    }
    public void LevelSucces()
    {
        OnLevelSuccess?.Invoke();
        
    }

    public void LevelFail()
    {
        OnLevelFail?.Invoke();
    }
}
