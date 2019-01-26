using System.Collections;
using System.Collections.Generic;
using InControl;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    protected const float _minimalInputVale = .2f;
    protected float myMinimalInputVale;
    protected bool setMinimalInputValue;

    public PlayerEntity entity;

    protected PlayerMovement movement;
    protected PlayerGrab itemGrab;

    protected float horizontal, vertical;
    protected float horizontalRotation, verticalRotation;
    protected bool grabItem, shouldMove, shouldntRotate;

    protected Vector3 lastMoveVector, lastRotationVector;

    public MeshRenderer coloredMesh;

    void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        itemGrab = GetComponent<PlayerGrab>();
    }

    void Update()
    {
        if (entity == null) return;
        else SetMinimalInputValue();
        CollectInputs();
        HandleInputs();
    }

    void SetMinimalInputValue()
    {
        if(!setMinimalInputValue)
        {
            setMinimalInputValue = true;
            myMinimalInputVale = entity.controllerType == PlayerEntity.PlayerControllerType.Keyboard ? 0 : _minimalInputVale;
        }
    }

    protected void CollectInputs()
    {
        if (entity.controllerType == PlayerEntity.PlayerControllerType.Keyboard)
        {
            shouldMove = !Input.GetButton("Fire1" + entity.numberOfControllerType.ToString());
            shouldntRotate = Input.GetButton("Fire2" + entity.numberOfControllerType.ToString());

            horizontalRotation = Input.GetAxis("Horizontal" + entity.numberOfControllerType.ToString());
            verticalRotation = Input.GetAxis("Vertical" + entity.numberOfControllerType.ToString());

            if (shouldMove)
            {
                horizontal = horizontalRotation;
                vertical = verticalRotation;
            }

            grabItem = Input.GetButtonDown("Fire0" + entity.numberOfControllerType.ToString());
        }
        else if (entity.controllerType == PlayerEntity.PlayerControllerType.Pad && entity.inputDevice != null)
        {
            shouldMove = true;
            shouldntRotate = entity.inputDevice.Action4;

            horizontal = entity.inputDevice.LeftStickX;
            vertical = entity.inputDevice.LeftStickY;

            horizontalRotation = entity.inputDevice.LeftStickX;
            verticalRotation = entity.inputDevice.LeftStickY;

            grabItem = entity.inputDevice.Action1.WasPressed;
        }
    }

    protected void HandleInputs()
    {
        lastMoveVector = new Vector3(horizontal, 0, vertical);
        lastRotationVector = new Vector3(horizontalRotation, 0, verticalRotation);

        if (shouldMove && (Mathf.Abs(horizontal) > _minimalInputVale || Mathf.Abs(vertical) > _minimalInputVale)) movement.Move(lastMoveVector);
        else movement.Idle();

        if(!shouldntRotate && (Mathf.Abs(horizontalRotation) > _minimalInputVale || Mathf.Abs(verticalRotation) > _minimalInputVale))
            movement.Rotate(lastRotationVector);
        else movement.RotationIdle();

        if(grabItem) itemGrab.Grab();
    }
}
