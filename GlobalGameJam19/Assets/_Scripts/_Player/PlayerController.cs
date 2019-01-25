using System.Collections;
using System.Collections.Generic;
using InControl;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    protected const float _minimalInputVale = .2f;

    public PlayerEntity entity;

    protected PlayerMovement movement;
    protected PlayerGrab itemGrab;

    protected float horizontal, vertical;
    protected bool grabItem;

    protected Vector3 lastMoveVector;

    public MeshRenderer coloredMesh;

    void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        itemGrab = GetComponent<PlayerGrab>();
    }

    void Update()
    {
        if(entity == null) return;
        CollectInputs();
        HandleInputs();
    }

    protected void CollectInputs()
    {
        if (entity.controllerType == PlayerEntity.PlayerControllerType.Keyboard)
        {
            horizontal = Input.GetAxis("Horizontal" + entity.numberOfControllerType.ToString());
            vertical = Input.GetAxis("Vertical" + entity.numberOfControllerType.ToString());

            grabItem = Input.GetButtonDown("Fire0" + entity.numberOfControllerType.ToString());
        }
        else if (entity.controllerType == PlayerEntity.PlayerControllerType.Pad && entity.inputDevice != null)
        {
            horizontal = entity.inputDevice.LeftStickX;
            vertical = entity.inputDevice.LeftStickY;

            grabItem = entity.inputDevice.Action1.WasPressed;
        }
    }

    protected void HandleInputs()
    {
        lastMoveVector = new Vector3(horizontal, 0, vertical);

        if (Mathf.Abs(horizontal) > _minimalInputVale || Mathf.Abs(vertical) > _minimalInputVale) movement.Move(lastMoveVector);
        else movement.Idle();

        if(grabItem) itemGrab.Grab();
    }
}
