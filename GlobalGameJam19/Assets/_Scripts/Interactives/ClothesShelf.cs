using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesShelf : Shelf {

    public Transform PlacePosition;
    public List<Transform> PlacePositions = new List<Transform>();

    protected override void OnTriggerEnter(Collider other)
    {
        ItemObject item = other.GetComponent<ItemObject>();

        if (item && !item.grabbed)
        {
            PutOn(item, PlacePositions[0]);
            PlacePositions.Remove(PlacePositions[0]);
        }

        if (itemOn != null)
        {
            if (itemOn.objectType == ItemObjectType.Cloth && item.status >= 1)
            {
                itemOn.GetComponent<Rigidbody>().isKinematic = true;
                itemOn.GetComponent<Rigidbody>().useGravity = false;
                itemOn.enabled = false;
                Destroy(item);
            }
            else
            {
                item.transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
            }
        }
    }
}
