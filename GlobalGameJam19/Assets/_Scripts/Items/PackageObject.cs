using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageObject : ItemObject
{
    public bool goodCondition = true;
    public GameObject crackObject;

    public void RepairCondition()
    {
        goodCondition = true;
        if (crackObject != null)
        {
            Destroy(crackObject);
        }
    }

    public void BadCondition()
    {
        goodCondition = false;
    }
}
