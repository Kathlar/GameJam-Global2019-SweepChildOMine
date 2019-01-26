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
    public GameObject fiut;

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
            if (itemOn.objectType == ItemObjectType.Cloth && itemOn.status == 0 && !IsWorking)
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
                itemOn.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
    }

    private void OpenWaschingMachine()
    {
        window.GetComponent<MeshRenderer>().enabled = false;
        animator.enabled = false;
        sound.Stop();
        transform.rotation = rotaion;
        IsWorking = false;
        Invoke("AddClothes", 0.5f);
    }

    private void AddClothes()
    {
        if (Clothes.Count > 0)
        {
            Clothes[0].GetComponent<ItemObject>().originalParent = null;
            Clothes[0].transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
            Clothes[0].GetComponent<MeshRenderer>().enabled = true;
            Clothes[0].transform.SetParent(fiut.transform);
            Clothes.RemoveAt(0);
        }
    }
}
