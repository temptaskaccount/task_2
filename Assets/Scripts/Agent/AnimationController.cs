using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    public Animator animator;

    public void Dance()
    {
        animator.SetTrigger("Dance");
    }

    public void Move()
    {
        animator.SetTrigger("Move");
    }

    public void Idle()
    {
        animator.SetTrigger("Fail");

    }
}
