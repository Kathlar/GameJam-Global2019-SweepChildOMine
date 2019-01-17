using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMovement : AMovement
{
    public float moveSpeed = 5f;

    protected override void DoMove()
    {
        transform.position += lastMoveDirection * moveSpeed * Time.fixedDeltaTime;
    }
}
