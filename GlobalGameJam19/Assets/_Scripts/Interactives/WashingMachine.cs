using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashingMachine : Shelf {

    int currentCapacity = 0;
    public GameObject window;
    public Animator animator;
    Quaternion rotaion;

    protected override void OnTriggerEnter(Collider other)
    {
        ItemObject item = other.GetComponent<ItemObject>();
        if (item && !item.grabbed)
        {
            PutOn(item);
        }

        if (itemOn != null)
        {
            if (itemOn.objectType == ItemObjectType.Cloth && item.status == 0)
            {
                itemOn.enabled = false;
                rotaion = transform.rotation;
                Destroy(item.gameObject);
                currentCapacity += 1;
                if(currentCapacity == 1)
                    window.GetComponent<MeshRenderer>().enabled = true;
                Invoke("OpenWaschingMachine", 5f);
                animator.SetBool("waschingMachine", true);
            }
            else
                item.transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
        }
    }

    private void OpenWaschingMachine()
    {
        window.GetComponent<MeshRenderer>().enabled = false;
        animator.enabled = false;
        transform.rotation = rotaion;
    }
}
