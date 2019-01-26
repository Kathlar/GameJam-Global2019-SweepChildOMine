using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : Shelf
{
    protected AudioSource throwAwaySound;

    private void Awake()
    {
        throwAwaySound = GetComponent<AudioSource>();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        throwAwaySound.Play();
        base.OnTriggerEnter(other);
        ItemObject item = other.GetComponent<ItemObject>();
        if (itemOn != null && itemOn.objectType == ItemObjectType.Trash)
            Destroy(item.gameObject);
    }
}
