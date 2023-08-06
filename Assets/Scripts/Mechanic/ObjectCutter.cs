using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCutter : MonoBehaviour
{
    #region Instance
    
    public static ObjectCutter instance;

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
    public GameObject CutObjectPrefab;

    public void CutObject(bool Isleft,float distance,GameObject _sended)
    {
        float cutSize = distance;
        
        Vector3 startScale = _sended.transform.localScale;
        float objecLength = startScale.x;
        Vector3 startPosition = _sended.transform.position;
        
        
        
        GameObject generated = Instantiate(CutObjectPrefab);
        
        generated.GetComponent<MeshRenderer>().material = _sended.GetComponent<MeshRenderer>().material;
        
        generated.transform.localScale = new Vector3(cutSize, startScale.y , startScale.z );
        
        float newObjectPosition = _sended.transform.position.x;
        newObjectPosition += Isleft ? (objecLength - cutSize)/2: - (objecLength - cutSize)/2;
        generated.transform.position = new Vector3(newObjectPosition, startPosition.y, startPosition.z);
        
        _sended.transform.localScale = new Vector3(objecLength-cutSize, startScale.y , startScale.z );
        
        float mainObjectPosition = _sended.transform.position.x;
        mainObjectPosition+= Isleft ? -(cutSize)/2: cutSize/2;
        _sended.transform.position = new Vector3(mainObjectPosition, startPosition.y, startPosition.z);
    }
    
    
}
