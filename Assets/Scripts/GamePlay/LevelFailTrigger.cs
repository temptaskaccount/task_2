using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFailTrigger : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.CompareTag("Player"))
         GamePlayManager.instance.LevelFail();
   }
}
