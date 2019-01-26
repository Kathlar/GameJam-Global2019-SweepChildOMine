using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    protected PlayerMovement movement;

    public Transform grabPosition;

    protected ItemObject itemToGrab;
    public ItemObject grabbedItem;
    protected Couch grabbedCouch;

    protected bool itemGrabbed;

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
        if(itemGrabbed) DoDrop();
        else DoGrab();
    }

    protected void DoGrab()
    {
        if (itemToGrab != null)
        {
            if (!itemToGrab.Grab(grabPosition, this)) return;
            itemGrabbed = true;
            grabbedItem = itemToGrab;
            itemToGrab = null;
            grabbedItem.DoMove(Vector3.zero, .5f, 1f);

            Couch couch = grabbedItem.GetComponent<Couch>();
            if(couch != null)
            {
                this.grabbedCouch = couch;
            }
        }
    }

    protected void DoDrop()
    {
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
