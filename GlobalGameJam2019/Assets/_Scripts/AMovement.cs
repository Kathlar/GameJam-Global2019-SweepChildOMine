using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AMovement : MonoBehaviour
{
    protected Vector3 lastMoveDirection;

    void FixedUpdate()
    {
        if(lastMoveDirection != Vector3.zero) DoMove();
        else DoIdle();
    }

    public void Move(Vector3 moveDirection)
    {
        lastMoveDirection = moveDirection;
    }

    protected abstract void DoMove();

    public void Idle()
    {
        lastMoveDirection = Vector3.zero;
    }

    protected virtual void DoIdle()
    {

    }
}
