using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateShelf : Shelf
{
    public Transform placePosition1;
    public Transform placePosition2;
    public Transform placePosition3;
    public Transform placePosition4;
    public Transform placePosition5;
    public Transform placePosition6;
    public Transform placePosition7;
    public Transform placePosition8;
    public Transform placePosition9;
    public Transform placePosition10;
    public Transform placePosition11;

    public List<Transform> platePositions = new List<Transform>();

    protected override void OnTriggerEnter(Collider other)
    {
        ItemObject item = other.GetComponent<ItemObject>();

        if (item && !item.grabbed)
        {
            PutOn(item, platePositions[0]);
            platePositions.Remove(platePositions[0]);
        }

        if (itemOn != null)
        {
            if (itemOn.objectType == ItemObjectType.Plate && item.status >= 1)
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
