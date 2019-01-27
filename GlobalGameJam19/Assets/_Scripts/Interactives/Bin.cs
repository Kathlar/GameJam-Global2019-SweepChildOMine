using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : Shelf
{
    protected AudioSource throwAwaySound;
    public List<GameObject> garbageBags = new List<GameObject>();
    int currCapacity = 0;
    public int Capacity = 5;

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
        {
            Destroy(item.gameObject);
            currCapacity += 1;
            if(currCapacity == Capacity)
            {
                currCapacity = 0;
                if (garbageBags.Count > 0)
                {
                    //garbageBags[0].transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
                    garbageBags[0].GetComponent<MeshRenderer>().enabled = true;
                    //Clothes[0].transform.SetParent(fiut.transform);
                    garbageBags.RemoveAt(0);
                }

            }
        }
    }
}
