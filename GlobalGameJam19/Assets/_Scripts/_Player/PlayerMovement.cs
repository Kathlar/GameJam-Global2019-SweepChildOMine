using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector] public float moveSpeed = 7f, actualMoveSpeed;
    [SerializeField] protected float rotateSpeed = 5f;

    protected Vector3 lastMoveVector, lastLookDirection;
    protected bool shouldMove, shouldRotate;

    private void Start()
    {
        actualMoveSpeed = moveSpeed;
    }

    void FixedUpdate()
    {
        if (shouldMove)
        {
            transform.position += transform.forward * actualMoveSpeed * Time.fixedDeltaTime;
        }
        if(shouldRotate)
        {
            Quaternion lookOnLook = Quaternion.LookRotation(lastLookDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookOnLook, Time.fixedDeltaTime * rotateSpeed);
        }
    }

    public void Move(Vector3 direction)
    {
        shouldMove = true;
        lastMoveVector = direction;
    }

    public void Idle()
    {
        shouldMove = false;
        lastMoveVector = Vector3.zero;
    }

    public void Rotate(Vector3 direction)
    {
        shouldRotate = true;
        lastLookDirection = direction;
    }

    public void RotationIdle()
    {
        shouldRotate = false;
        lastLookDirection = Vector3.zero;
    }
}
