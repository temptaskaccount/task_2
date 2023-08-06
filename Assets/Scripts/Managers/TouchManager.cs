using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TouchManager : MonoBehaviour
{
    
    #region Instance
    
    public static TouchManager instance;

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
    public UnityAction OnTouch;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            OnTouch?.Invoke();
    }

    private void OnDestroy()
    {
        OnTouch = null;
    }
}
