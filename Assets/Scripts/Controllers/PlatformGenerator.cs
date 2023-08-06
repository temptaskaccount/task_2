using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlatformGenerator : MonoBehaviour
{
    
    #region Instance
    
    public static PlatformGenerator instance;

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
    
    public Platform PlatformPrefab;
    public GameObject CurrentPlatform;
    private  LevelController CurrentLevelController;
    public UnityAction OnPlatformApply;
    
    private int GeneratedPlatformCount;
    private bool IsRıght;
    public void InitilaizeNewLevel(LevelController levelController)
    {
        CurrentLevelController = levelController;
        CurrentPlatform = CurrentLevelController.FirstPlatformPoint.gameObject;
        GeneratedPlatformCount = 0;
    }

    public void RequestPlatform()
    {
        if(GeneratedPlatformCount ==CurrentLevelController.LevelData.LevelLength)
            return;
        float xposition = IsRıght ? 1 : -1;
        Platform created = Instantiate(PlatformPrefab, new Vector3((xposition *3)+ CurrentPlatform.transform.position.x,
            CurrentPlatform.transform.position.y, CurrentPlatform.transform.position.z +3), Quaternion.identity, CurrentLevelController.transform);
        created.Initilaize(CurrentPlatform.transform);
        created.InitilaizeMaterial(CurrentLevelController.LevelData.ColorData.Materials[GeneratedPlatformCount]);

        
        IsRıght = !IsRıght;
        GeneratedPlatformCount++;
        CurrentPlatform = created.gameObject;
    }
    public void PlatformApply()
    {
        OnPlatformApply?.Invoke();
    }
}
