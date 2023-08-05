using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
   public List<LevelData> Levels;
   public LevelController LevelController;

   [HideInInspector]
   public LevelController CurrentLevel;

   private void Awake()
   {
       GenerateLevel(true);
   }

   public void GenerateLevel(bool IsFirst = false)
   {
       float length = 0;
         if (!IsFirst)
         {
             length = 10;
         }
         CurrentLevel = Instantiate(LevelController,new Vector3(0,0,length),Quaternion.identity);
         CurrentLevel.Initilaize(Levels[DataManager.LevelIndex % Levels.Count],IsFirst);
    
   }
}
