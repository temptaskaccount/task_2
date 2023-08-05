using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public LevelData LevelData;
    public GameObject StartPlatform;
    public void Initilaize(LevelData _sended,bool IsFirst)
    {
        if(IsFirst)
            StartPlatform.gameObject.SetActive(true);
        LevelData = _sended;
    }
}
