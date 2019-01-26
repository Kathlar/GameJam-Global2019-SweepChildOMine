using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : AInteractive
{
    public Transform placePosition;
    [HideInInspector] public ItemObject itemOn;

    protected virtual void OnTriggerEnter(Collider other)
    {
        ItemObject item = other.GetComponent<ItemObject>();

        if (item && !item.grabbed)
        {
            PutOn(item);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ItemObject item = other.GetComponent<ItemObject>();

        if (item == itemOn)
        {
            PutOff();
        }
    }

    protected virtual void PutOn(ItemObject item, Transform placePosition = null)
    {
        item.transform.position = placePosition.position;
        item.transform.rotation = placePosition.rotation;
        itemOn = item;
        itemOn.objectOn = this;
    }

    public virtual void PutOff()
    {
        if (itemOn != null)
        {
            itemOn = null;
        }
    }
}
