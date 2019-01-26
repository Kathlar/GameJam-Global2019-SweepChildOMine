using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashingMachine : Shelf {


    protected override void OnTriggerEnter(Collider other)
    {
        ItemObject item = other.GetComponent<ItemObject>();
        base.OnTriggerEnter(other);
        if (itemOn != null)
        {
            if (itemOn.objectType == ItemObjectType.Cloth && item.status == 0)
                itemOn.enabled = false;
            else
                item.transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
        }
    }
}
