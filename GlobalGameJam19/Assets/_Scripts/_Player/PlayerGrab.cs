using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    public Transform grabPosition;

    protected ItemObject itemToGrab;
    protected ItemObject grabbedItem;

    protected bool itemGrabbed;

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
    }

    public void Grab()
    {
        if(itemGrabbed) DoDrop();
        else DoGrab();
    }

    protected void DoGrab()
    {
        if (itemToGrab != null && !itemToGrab.grabbed)
        {
            itemGrabbed = true;
            grabbedItem = itemToGrab;
            itemToGrab = null;
            grabbedItem.Grab(grabPosition);
            grabbedItem.transform.DOLocalMove(Vector3.zero, .5f);
            grabbedItem.transform.DOLocalRotate(Vector3.zero, 1);
        }
    }

    protected void DoDrop()
    {
        itemGrabbed = false;
        grabbedItem.Drop();
        itemToGrab = grabbedItem;
        grabbedItem = null;
    }
}
