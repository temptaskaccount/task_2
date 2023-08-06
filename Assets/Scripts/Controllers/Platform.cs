using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
   public Transform OtherPlatform;
   private Vector3 moveDir;
   private bool IsMove;
   public void Initilaize(Transform BeforePlatform)
   {
       OtherPlatform = BeforePlatform;
       transform.localScale = new Vector3(OtherPlatform.localScale.x, transform.localScale.y, transform.localScale.z);
       moveDir = transform.position.x > OtherPlatform.position.x ? Vector3.left : Vector3.right;
       IsMove = true;
       TouchManager.instance.OnTouch += CheckPlatfrorm;
   }

   private void Update()
   {
       if(IsMove)
        transform.position += moveDir * (Time.deltaTime * 2);
   }

   [ContextMenu("CheckIsSuccess")]
   public void CheckPlatfrorm()
   {
       IsMove = false;
       float Difference = Mathf.Abs(transform.position.x - OtherPlatform.position.x);
       
       if (Difference >= transform.localScale.x)
       {
           gameObject.AddComponent<ObjectDropper>();
           GamePlayManager.instance.LevelFail();
           return;
       }


       if (Difference < 0.25f)
       {
          transform.position = new Vector3(OtherPlatform.position.x, transform.position.y, transform.position.z);
           SoundManager.instance.SuccesPlatform();
       }
       else
       { 
           SoundManager.instance.ResetCombo();
           if (transform.localScale.x - Difference < 0.3f)
           {
               GamePlayManager.instance.LevelFail();
               gameObject.AddComponent<ObjectDropper>();
               return;
           }
            
           
           ObjectCutter.instance.CutObject(transform.position.x > OtherPlatform.position.x, Difference, gameObject);
       }
       PlatformGenerator.instance.PlatformApply();
       PlatformGenerator.instance.RequestPlatform();
       TouchManager.instance.OnTouch -= CheckPlatfrorm;
   }

   public void InitilaizeMaterial(Material mat)
   {
       GetComponent<MeshRenderer>().material = mat;
   }
}
