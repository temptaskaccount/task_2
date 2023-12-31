using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FinishParticle : MonoBehaviour
{
   public Transform StarParticle;
   private void Start()
   {
      transform.DOMoveY(transform.position.y + 5, 4).OnComplete(() => Destroy(gameObject));
      StarParticle.transform.DOLocalMoveX(4f, 4);
   }

   private void Update()
   {
      transform.Rotate(0,Time.deltaTime+15,0);
   }
}
