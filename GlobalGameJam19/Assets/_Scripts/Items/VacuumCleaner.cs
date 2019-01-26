using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumCleaner : ItemObject
{
    private void OnTriggerEnter(Collider other)
    {
        Dirt dirt = other.GetComponent<Dirt>();

        if(dirt != null)
        {
            dirt.Collect();
        }
    }

    public override bool Grab(Transform parent = null, PlayerGrab player = null)
    {
        bool reslt = base.Grab(parent, player);
        //foreach(Collider col in colliders)
        //{
        //    col.enabled = true;
        //}
        return reslt;
    }
}
