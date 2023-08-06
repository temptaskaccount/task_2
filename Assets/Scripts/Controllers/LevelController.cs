using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public LevelData LevelData;
    public GameObject StartPlatform;
    public Transform FirstPlatformPoint;
    int RequestedPlatformCount = 0;
    public FinishArea FinishPoint;
   
    public void Initilaize(LevelData _sended,bool IsFirst)
    {
        if(IsFirst)
            StartPlatform.gameObject.SetActive(true);
        LevelData = _sended;
        PlatformGenerator.instance.InitilaizeNewLevel(this);
        FinishPoint = Instantiate(FinishPoint, new Vector3(0, 0, FirstPlatformPoint.transform.position.z +LevelData.LevelLength *3 + 2.4f), Quaternion.identity);
    }

   
}
