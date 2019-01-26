using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : Shelf
{
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        ItemObject item = other.GetComponent<ItemObject>();
        if (itemOn != null && itemOn.objectType == ItemObjectType.Trash)
            Destroy(item.gameObject);
    }
}
