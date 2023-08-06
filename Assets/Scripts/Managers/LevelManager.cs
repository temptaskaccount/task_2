using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    
    #region Instance
    
    public static LevelManager instance;

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
    
   public List<LevelData> Levels;
   public LevelController LevelController;

   [HideInInspector]
   public LevelController CurrentLevel;

   private void Start()
   {
       GenerateLevel(true);
       GamePlayManager.instance.OmLevelStart += RequestLevel;
   }

   void RequestLevel()
   {
       Destroy(CurrentLevel.gameObject,5f);
       GenerateLevel();
   }

   public void GenerateLevel(bool IsFirst = false)
   {
       float length = 0;
         if (!IsFirst)
         {
             length = CurrentLevel.FinishPoint.transform.position.z;
         }
         CurrentLevel = Instantiate(LevelController,new Vector3(0,0,length),Quaternion.identity);
         CurrentLevel.Initilaize(Levels[DataManager.LevelIndex % Levels.Count],IsFirst);
    
   }

   private void OnDestroy()
   {
       GamePlayManager.instance.OmLevelStart -= RequestLevel;
   }
}
