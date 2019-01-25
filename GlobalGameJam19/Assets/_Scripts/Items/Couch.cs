using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Couch : ItemObject
{
    public Transform leftPoint, rightPoint;

    protected bool leftGrabbed, rightGrabbed;

    public GameObject regularState, grabbedRightState, grabbedLeftState, grabbedBothState;

    protected Transform leftPlayer, rightPlayer;

    protected State myState;

    private Vector3 length, center;

    protected List<GameObject> allStates = new List<GameObject>();

    private void Start()
    {
        allStates.Add(regularState);
        allStates.Add(grabbedRightState);
        allStates.Add(grabbedLeftState);
        allStates.Add(grabbedBothState);

        DoSetState(State.Regular);
    }

    private void Update()
    {
        length = rightPoint.position - leftPoint.position;
        center = length / 2 + leftPoint.position;
    }

    public override bool Grab(Transform parent = null, PlayerGrab player = null)
    {
        Transform closerPoint = (Vector3.Distance(parent.position, leftPoint.position) < Vector3.Distance(parent.position, rightPoint.position) ? leftPoint : rightPoint);
        if (closerPoint == leftPoint)
        {
            if(!leftGrabbed)
            {
                leftGrabbed = true;
                leftPlayer = player.transform;
                SetState(State.Left);

            }
            else
            {
                return false;
            }
        }
        else
        {
            if (!rightGrabbed)
            {
                rightGrabbed = true;
                rightPlayer = player.transform;
                SetState(State.Right);
            }
            else
            {
                return false;
            }
        }
        grabbed = true;
        if (objectOn != null) objectOn.PutOff();

        rb.useGravity = false;

        closerPoint.transform.position += Vector3.up;

        return true;
    }

    public override void Drop(PlayerGrab player = null)
    {
        base.Drop(player);
        SetState(State.Regular);

        if(player == leftPlayer)
        {
            leftPlayer = null;
            leftGrabbed = false;
        }
        if(player == rightPlayer)
        {
            rightPlayer = null;
            rightGrabbed = false;
        }
    }

    void SetState(State proposedState)
    {
        if (proposedState == State.Regular) myState = proposedState;

        if (myState == State.Regular) myState = proposedState;
        else if (myState == State.Left && proposedState == State.Right) myState = State.Both;
        else if (myState == State.Right && proposedState == State.Left) myState = State.Both;


        if(myState == State.Regular)
        {

        }

        DoSetState(myState);
    }

    protected void DoSetState(State proposedState)
    {
        foreach(GameObject state in allStates)
        {
            state.SetActive(false);
        }

        if (proposedState == State.Regular) regularState.SetActive(true);
        else if (proposedState == State.Left) grabbedLeftState.SetActive(true);
        else if (proposedState == State.Right) grabbedRightState.SetActive(true);
        else if (proposedState == State.Both) grabbedBothState.SetActive(true);
    }

    public override void DoMove(Vector3 localPos, float moveTime = 0.5F, float rotateTime = 1)
    {

    }

    protected enum State
    {
        Regular, Left, Right, Both
    }
}
