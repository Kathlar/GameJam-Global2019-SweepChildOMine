using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AInteractive : MonoBehaviour
{
    public Transform placePosition;
    [HideInInspector] public ItemObject itemOn;

    public ProgressBar progressBar;

    protected virtual void Start()
    {
        progressBar = Instantiate(PrefabDatabase.Instance.progressBarPrefab, GlobalVariables.Instance.mainCanvas.transform).GetComponent<ProgressBar>();
        progressBar.Hide();
        progressBar.SetValue(0);
    }

    protected virtual void Update()
    {
        SetProgressBar();
    }

    protected virtual void SetProgressBar()
    {
        progressBar.SetPosition(transform.position + transform.up * 3);
    }

    private void OnTriggerEnter(Collider other)
    {
        ItemObject item = other.GetComponent<ItemObject>();

        if(item && !item.grabbed)
        {
            PutOn(item);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ItemObject item = other.GetComponent<ItemObject>();

        if (item == itemOn)
        {
            PutOff();
        }
    }

    void PutOn(ItemObject item)
    {
        item.transform.position = placePosition.position;
        itemOn = item;
    }

    void PutOff()
    {
        if(itemOn != null)
        {
            itemOn = null;
        }

        progressBar.Hide();
    }
}
