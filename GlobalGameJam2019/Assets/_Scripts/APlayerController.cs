using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class APlayerController : MonoBehaviour
{
    protected Rotator rotator;
    protected AMovement movement;
    protected AAttack atack;

    protected float horizontal, vertical;
    protected float horizontalSecondary, verticalSecondary;
    protected Vector3 moveVector, rotateVector;
    protected bool shooting;

    protected virtual void Awake()
    {
        movement = GetComponent<AMovement>();
        rotator = GetComponent<Rotator>();
        atack = GetComponent<AAttack>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        CollectInputs();
        HandleInputs();
    }

    protected abstract void CollectInputs();

    protected void HandleInputs()
    {
        moveVector = new Vector3(horizontal, 0, vertical);
        rotateVector = new Vector3(horizontalSecondary, 0, verticalSecondary);

        if (Mathf.Abs(horizontal) > .2f || Mathf.Abs(vertical) > .2f)
        {
            movement.Move(moveVector);
        }
        else movement.Idle();

        if (Mathf.Abs(horizontalSecondary) > .2f || Mathf.Abs(verticalSecondary) > .2f)
            rotator.Rotate(rotateVector);
        
        if (shooting && atack.enabled) atack.Attack();
    }
}
