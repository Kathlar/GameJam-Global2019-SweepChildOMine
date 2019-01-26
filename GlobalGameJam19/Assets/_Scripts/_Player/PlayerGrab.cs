using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    protected PlayerMovement movement;

    public Transform grabPosition;

    protected ItemObject itemToGrab;
    protected ItemObject grabbedItem;
    protected Couch grabbedCouch;

    [HideInInspector] public bool itemGrabbed;

    [HideInInspector] public bool inProgress;

    public Collider grabbedCollider;

    public Transform hands;
    public Transform handsUpPoint;
    public Transform regularHandsPoint;

    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (!itemGrabbed)
        {
            ItemObject item = col.GetComponent<ItemObject>();

            if (item)
            {
                itemToGrab = item;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ItemObject item = other.GetComponent<ItemObject>();

        if (item && item == itemToGrab)
        {
            itemToGrab = null;
        }

        Couch couch = other.GetComponent<Couch>();
        if (couch != null && couch == grabbedCouch) DoDrop();
    }

    public void Grab()
    {
        if (inProgress) return;
        if(itemGrabbed) DoDrop();
        else DoGrab();
    }

    protected void DoGrab()
    {
        if (itemToGrab != null)
        {
            hands.DOLocalMove(handsUpPoint.localPosition, .8f);
            hands.DOLocalRotate(handsUpPoint.localEulerAngles, .8f);
            //hands.DOScale(handsUpPoint.localScale, .8f);
            inProgress = true;
            movement.actualMoveSpeed = .6f * movement.moveSpeed;
            if (!itemToGrab.Grab(grabPosition, this)) return;
            itemGrabbed = true;
            grabbedItem = itemToGrab;
            itemToGrab = null;
            grabbedItem.DoMove(Vector3.zero, this, .5f, 1f);

            Couch couch = grabbedItem.GetComponent<Couch>();
            if(couch != null)
            {
                this.grabbedCouch = couch;
            }
            grabbedCollider.enabled = true;
        }
    }

    protected void DoDrop()
    {
        hands.DOLocalMove(regularHandsPoint.localPosition, .8f);
        hands.DOLocalRotate(regularHandsPoint.localEulerAngles, .8f);
        //hands.DOScale(regularHandsPoint.localScale, .8f);
        grabbedCollider.enabled = false;
        movement.actualMoveSpeed = movement.moveSpeed;
        itemGrabbed = false;
        if (grabbedItem != null)
        {
            grabbedItem.Drop(this);
        }
        itemToGrab = grabbedItem;
        grabbedItem = null;
        grabbedCouch = null;
    }
}
