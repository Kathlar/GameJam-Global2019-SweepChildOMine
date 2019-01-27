using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : Shelf
{
    protected override void OnTriggerEnter(Collider other)
    {
        ItemObject item = other.GetComponent<ItemObject>();

        if (item && !item.grabbed)
        {
            PutOn(item, placePosition);
        }
        if (itemOn != null && itemOn.objectType == ItemObjectType.GarbageBag)
            Destroy(item.gameObject);
    }
}
