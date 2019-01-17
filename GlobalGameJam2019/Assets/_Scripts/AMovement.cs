using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AMovement : MonoBehaviour
{
    public Animator animator;

    protected Vector3 lastMoveDirection;

    void FixedUpdate()
    {
        if(lastMoveDirection != Vector3.zero) DoMove();
        else DoIdle();
    }

    public void Move(Vector3 moveDirection)
    {
        lastMoveDirection = moveDirection;
        animator.SetBool("Move", true);
    }

    protected abstract void DoMove();

    public void Idle()
    {
        lastMoveDirection = Vector3.zero;
        animator.SetBool("Move", false);
    }

    protected virtual void DoIdle()
    {

    }
}
