using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
     public CinemachineVirtualCamera followCamera;
     public CinemachineVirtualCamera succesCamera;
     
     CinemachineTrackedDolly dolly;
     private Coroutine _coroutine;

     private void Start()
     {
          dolly =   succesCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
          GamePlayManager.instance.OnLevelSuccess += ActivateSuccesCamera;
          GamePlayManager.instance.OmLevelStart += ActiveFollowCamera;
          GamePlayManager.instance.OnLevelFail += DeActiveCameras;
     }

     Coroutine _cameraCoroutine;
     public void ActiveFollowCamera()
     {
          if(_coroutine != null)
               StopCoroutine(_coroutine);
          followCamera.gameObject.SetActive(true);
          succesCamera.gameObject.SetActive(false);
     }
     public void ActivateSuccesCamera()
     {
          succesCamera.gameObject.SetActive(true);
          followCamera.gameObject.SetActive(false);
       
          _coroutine = StartCoroutine(CameraCoroutine());
          IEnumerator CameraCoroutine()
          {
               dolly.m_PathPosition = -5;
               while (true)
               {
                    
                    dolly.m_PathPosition += 1 * Time.deltaTime;

                    yield return null;
               }
               followCamera.gameObject.SetActive(true);
               succesCamera.gameObject.SetActive(false);
          }
     }

     public void DeActiveCameras()
     {
          followCamera.gameObject.SetActive(false);
          succesCamera.gameObject.SetActive(false);
     }

     private void OnDestroy()
     {
          GamePlayManager.instance.OnLevelSuccess -= ActivateSuccesCamera;
          GamePlayManager.instance.OmLevelStart -= ActiveFollowCamera;
          GamePlayManager.instance.OnLevelFail -= DeActiveCameras;
     }
}
