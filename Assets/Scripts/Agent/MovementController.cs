using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float Speed;
    bool Move = false;
    AnimationController animationController;

    private void Start()
    {
        animationController = GetComponent<AnimationController>();
        StartMovement();
        GamePlayManager.instance.OnLevelSuccess += MoveFinishArea;
        GamePlayManager.instance.OnLevelFail += Fail;
        GamePlayManager.instance.OmLevelStart += LevelStart;
        PlatformGenerator.instance.OnPlatformApply += MoveCurrentXposition;
    }

    public void StartMovement()
    {
        Move = true;
        animationController.Move();
    }
    private void Update()
    {
        if(!Move)
            return;
        transform.position += Vector3.forward * (Speed * Time.deltaTime);
    }

    public void LevelStart()
    {
        StartMovement();
    }
    public void MoveCurrentXposition()
    {
        transform.DOMoveX(PlatformGenerator.instance.CurrentPlatform.transform.position.x, 0.4f);
    }

    public void Fail()
    {
        Move = false;
        animationController.Idle();
    }
    public void MoveFinishArea()
    {
        transform.DOMove(LevelManager.instance.CurrentLevel.FinishPoint.FinishAreaPosition.position, 0.6f).OnComplete(() =>
            {
                Move = false;
                animationController.Dance();
                
            });
    }

    private void OnDestroy()
    {
        GamePlayManager.instance.OnLevelSuccess -= MoveFinishArea;
        GamePlayManager.instance.OnLevelFail -= Fail;
        GamePlayManager.instance.OmLevelStart -= LevelStart;
        PlatformGenerator.instance.OnPlatformApply -= MoveCurrentXposition;

    }
}
