using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashingMachine : Shelf {

    int currentCapacity = 0;
    public GameObject window;
    public GameObject clothes;
    public Animator animator;
    Quaternion rotaion;
    public List<GameObject> Clothes = new List<GameObject>();
    bool IsWorking = false;
    protected AudioSource sound;

    private void Awake()
    {
        sound = GetComponent<AudioSource>();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        ItemObject item = other.GetComponent<ItemObject>();
        if (item && !item.grabbed)
        {
            PutOn(item);
        }

        if (itemOn != null)
        {
            if (itemOn.objectType == ItemObjectType.Cloth && item.status == 0 && !IsWorking)
            {
                itemOn.enabled = false;
                rotaion = transform.rotation;
                Destroy(item.gameObject);
                currentCapacity += 1;
                if (currentCapacity == 1)
                {
                    IsWorking = true;
                    window.GetComponent<MeshRenderer>().enabled = true;
                    Invoke("OpenWaschingMachine", 5f);
                    animator.enabled = true;
                    animator.SetBool("waschingMachine", true);
                    sound.Play();
                    currentCapacity = 0;
                }
            }
            else
                item.transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
        }
    }

    private void OpenWaschingMachine()
    {
        window.GetComponent<MeshRenderer>().enabled = false;
        animator.enabled = false;
        sound.Stop();
        transform.rotation = rotaion;
        if (Clothes.Count > 0)
        {
            Clothes[0].transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1.5f);
            Clothes[0].GetComponent<MeshRenderer>().enabled = true;
            Clothes[0].transform.SetParent(null);
            Clothes.Remove(Clothes[0]);
        }
        IsWorking = false;
    }
}
