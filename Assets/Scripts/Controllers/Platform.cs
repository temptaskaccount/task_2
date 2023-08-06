using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
   public Transform OtherPlatform;
   private Vector3 moveDir;
   private bool IsMove;
   public GameObject FailTrigger;
   public GameObject Coin;
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
           GenerateFailTrigger();
           gameObject.AddComponent<ObjectDropper>();
           return;
       }


       if (Difference < 0.25f)
       {
          transform.position = new Vector3(OtherPlatform.position.x, transform.position.y, transform.position.z);
          Instantiate(Coin,transform.position + new Vector3(0,1f,0),Quaternion.identity);
           SoundManager.instance.SuccesPlatform();
       }
       else
       { 
           SoundManager.instance.ResetCombo();
           if (transform.localScale.x - Difference < 0.3f)
           {
               GenerateFailTrigger();
               gameObject.AddComponent<ObjectDropper>();
               return;
           }
            
           
           ObjectCutter.instance.CutObject(transform.position.x > OtherPlatform.position.x, Difference, gameObject);
       }
       PlatformGenerator.instance.PlatformApply();
       PlatformGenerator.instance.RequestPlatform();
       TouchManager.instance.OnTouch -= CheckPlatfrorm;
   }

   void GenerateFailTrigger()
   {
       var created = Instantiate(FailTrigger);
       created.transform.position = new Vector3(OtherPlatform.position.x, transform.position.y, transform.position.z);
   }
   public void InitilaizeMaterial(Material mat)
   {
       GetComponent<MeshRenderer>().material = mat;
   }
}
